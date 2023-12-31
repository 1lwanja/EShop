﻿using BlazingShop.Client.Services.ProductService;
using BlazingShop.Client.Shared;
using BlazingShop.Shared;
using Blazored.LocalStorage;
using Blazored.Toast.Services;

namespace BlazingShop.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IProductService _productService;
        private readonly IToastService _toastService;

        public event Action OnChange;
        public CartService(
            ILocalStorageService localStorage,
            IToastService toastService,
            IProductService productService)
        {
            _localStorage = localStorage;
            _toastService = toastService;
            _productService = productService;

        }

        public async Task AddToCart(ProductVariant productVariant)
        {
            var cart = await _localStorage.GetItemAsync<List<ProductVariant>>("cart");
            if (cart == null)
            {
                cart = new List<ProductVariant>();
            }
            cart.Add(productVariant);
            await _localStorage.SetItemAsync("cart", cart);

            var product = await _productService.GetProductById(productVariant.ProductId);
            _toastService.ShowSuccess(product.Title);

            OnChange.Invoke();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var result = new List<CartItem>();
            var cart = await _localStorage.GetItemAsync<List<ProductVariant>>("cart");
            if ( cart == null )
            {
                return result;
            }
            foreach ( var item in cart )
            {
                var product = await _productService.GetProductById(item.ProductId);
                var cartItem = new CartItem
                {
                    ProductId = product.Id,
                    ProductTitle = product.Title,
                    Image = product.Image,
                    EditionId = item.EditionId
                };
                var variant = product.Variants.Find(v => v.EditionId == item.EditionId);
                if (variant != null)
                {
                    cartItem.EditionName = variant.Edition?.Name;
                    cartItem.Price = variant.Price;
                }
                result.Add(cartItem);
            }
            return result;
        }

        public async Task DeleteItem(CartItem item)
        {
            var cart = await _localStorage.GetItemAsync<List<ProductVariant>>("cart");
            if (cart == null )
            {
                return;
            }
            var cartItem = cart.Find(x =>  x.ProductId == item.ProductId && x.EditionId == item.EditionId);
            cart.Remove(cartItem);

            await _localStorage.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }
    }
}
