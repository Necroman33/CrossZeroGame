//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cross_zero_game
{
    using System;
    using System.Collections.Generic;
    
    public partial class Scores
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Nullable<int> Wins { get; set; }
        public Nullable<int> Draws { get; set; }
        public Nullable<int> Defeats { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
