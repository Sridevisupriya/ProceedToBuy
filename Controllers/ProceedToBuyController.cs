﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProceedToBuyService.Models;
using ProceedToBuyService.Provider;

namespace ProceedToBuyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceedToBuyController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ProceedToBuyController));
        private readonly IProceedToBuyProvider _provider;
        public ProceedToBuyController(IProceedToBuyProvider p)
        {
            this._provider = p;
        }



        // POST: api/ProceedToBuy
       [HttpPost]
        [Route("Cart/{prodid}/{custid}/{zipcode}/{delidt}")]
        public async Task<IActionResult> PostAddToCart(int prodid,int custid,int zipcode,DateTime delidt)
        {
            _log4net.Info("Add to Cart method initiated");
            try
            {
                CartDto result = await _provider.GetSupply(prodid,custid,zipcode,delidt);
                _log4net.Info("Added to Cart");
                return Ok(result);

            }
            catch
            {
                _log4net.Info("Cannot Add To Cart");
                return Ok(null);
            }
           
        }


          [HttpPost]
          [Route("Wishlist")]
          public IActionResult PostAddToWishList([FromBody] WishlistDto entity)
          {
              _log4net.Info("Add to WishList method initiated");
              try
            {
                  _log4net.Info("Add To Wishlist Provider called");
                  bool result = _provider.Add(entity);
                  if(result == true)
                  {
                      return Ok("Added to Wishlist");
                  }
                  else
                  {
                      return Ok("Not able to add data to Wishlist");   
                  }

              }
              catch
              {
                  _log4net.Info("Error calling Add Wishlist provider");
                  return StatusCode(500);
              }

          }


    }
}
