//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace autoService
{
    using System;
    using System.Collections.Generic;
    
    public partial class AmenitiesOrder
    {
        public long Id { get; set; }
        public long Amenities { get; set; }
        public long Order { get; set; }
    
        public virtual Amenities Amenities1 { get; set; }
        public virtual Order Order1 { get; set; }
    }
}
