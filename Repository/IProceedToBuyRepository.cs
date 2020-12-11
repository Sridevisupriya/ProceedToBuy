using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProceedToBuyService.Models;

namespace ProceedToBuyService.Repository
{
    public interface IProceedToBuyRepository
    {
        public IEnumerable<WishlistDto> addToWishlist(WishlistDto entity);
        public IEnumerable<CartDto> addToCart(CartDto entity);
    }
}
