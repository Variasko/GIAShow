﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GIADoneForShow
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EquipmentRepairEntities : DbContext
    {

        public static EquipmentRepairEntities _context;

        public EquipmentRepairEntities GetContext()
        {
            if (_context == null)
                _context = new EquipmentRepairEntities();

            return _context;
        }

        public EquipmentRepairEntities()
            : base("name=EquipmentRepairEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Deffect> Deffect { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EquipmentModel> EquipmentModel { get; set; }
        public virtual DbSet<EquipmentType> EquipmentType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}