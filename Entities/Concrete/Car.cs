﻿using Core.Entities;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string? Description { get; set; }
        public Brand Brand { get; set; }
        public Color Color { get; set; }
        public Rental Rental { get; set; }
    }
}
