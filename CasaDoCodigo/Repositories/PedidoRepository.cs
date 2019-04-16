﻿using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{


    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IItemPedidoRepository _itemPedidoRepository;

        public PedidoRepository(ApplicationContext context, IHttpContextAccessor contextAccessor, IItemPedidoRepository itemPedidoRepository) : base(context)
        {
            _contextAccessor = contextAccessor;
            _itemPedidoRepository = itemPedidoRepository;
        }

        public void AddItem(string codigo)
        {
            var produto = _context.Set<Produto>()
                            .Where(p => p.Codigo == codigo)
                            .SingleOrDefault();
            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = GetPedido();

            var itemPedido = _context.Set<ItemPedido>()
                                .Where(i => i.Produto.Codigo == codigo && i.Pedido.Id == pedido.Id)
                                .SingleOrDefault();
            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                _context.Set<ItemPedido>().Add(itemPedido);
                _context.SaveChanges();
            }
        }

        public Pedido GetPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido = dbSet
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefault();
            if (pedido == null)
            {
                pedido = new Pedido();
                dbSet.Add(pedido);
                _context.SaveChanges();
                SetPedidoId(pedido.Id);
            }
            return pedido;
        }

        private int? GetPedidoId()
        {
            return _contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            _contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }


        public UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido)
        {
            var _itemPedido = _itemPedidoRepository.GetItemPedido(itemPedido.Id);

            if (_itemPedido != null)
            {
                _itemPedido.AtualizaQuantidade(itemPedido.Quantidade);

                if (_itemPedido.Quantidade == 0 )
                {
                    _itemPedidoRepository.RemoveItemPedido(_itemPedido.Id);
                }
                _context.SaveChanges();

                var carrinhoViewModel = new CarrinhoViewModel(GetPedido().Itens);
                return new UpdateQuantidadeResponse(_itemPedido, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado");

        }
    }

}
