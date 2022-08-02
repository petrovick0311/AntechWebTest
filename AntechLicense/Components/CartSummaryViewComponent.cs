﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntechLicense.Models;
using Microsoft.AspNetCore.Mvc;

namespace AntechLicense.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
