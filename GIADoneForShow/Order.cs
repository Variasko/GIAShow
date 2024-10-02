//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int id { get; set; }
        public System.DateTime dateStart { get; set; }
        public Nullable<System.DateTime> dateEnd { get; set; }
        public int equipmentTypeId { get; set; }
        public int equipmentModelId { get; set; }
        public string equipmentSerial { get; set; }
        public int deffectId { get; set; }
        public string description { get; set; }
        public int clientId { get; set; }
        public Nullable<int> employeeId { get; set; }
        public string employeeComment { get; set; }
        public Nullable<int> statusId { get; set; }
        public Nullable<int> priorityId { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Deffect Deffect { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual EquipmentModel EquipmentModel { get; set; }
        public virtual EquipmentType EquipmentType { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Status Status { get; set; }
    }
}
