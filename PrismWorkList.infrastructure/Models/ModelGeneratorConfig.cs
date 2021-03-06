
// This file was automatically generated by the Dapper.FastCRUD T4 Template
// Do not make changes directly to this file - edit the template configuration instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `PGTraining`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=localhost\SQLEXPRESS;Initial Catalog=PGTraining;Integrated Security=True;`
//     Include Views:          `True`

namespace PrismWorkList.Infrastructure.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Collections.Generic;

    /// <summary>
    /// A class which represents the ExaminationOrders table.
    /// </summary>
	[Table("ExaminationOrders")]
	public partial class ExaminationOrder
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	    public virtual int ID { get; set; }
	    public virtual string OrderNumber { get; set; }
	    public virtual DateTime ExaminationDate { get; set; }
	    public virtual string ProcessingDivision { get; set; }
	    public virtual int InfoID { get; set; }
	    public virtual string ExaminationTypeCode { get; set; }
	    public virtual string ExaminationTypeName { get; set; }
	    public virtual string Comment { get; set; }
	}

    /// <summary>
    /// A class which represents the PatientInfomation table.
    /// </summary>
	[Table("PatientInfomation")]
	public partial class PatientInfomation
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	    public virtual int ID { get; set; }
	    public virtual string PatientID { get; set; }
	    public virtual string KanjiName { get; set; }
	    public virtual string KanaName { get; set; }
	    public virtual DateTime BirthDate { get; set; }
	    public virtual string Gender { get; set; }
	}

    /// <summary>
    /// A class which represents the ShotItems table.
    /// </summary>
	[Table("ShotItems")]
	public partial class ShotItem
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	    public virtual int ID { get; set; }
	    public virtual int OrderID { get; set; }
	    public virtual string ShotItemCode { get; set; }
	    public virtual string ShotItemName { get; set; }
	}

    /// <summary>
    /// A class which represents the Users table.
    /// </summary>
	[Table("Users")]
	public partial class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	    public virtual int ID { get; set; }
	    public virtual string UserID { get; set; }
	    public virtual string Password { get; set; }
	    public virtual string Salt { get; set; }
	    public virtual DateTime StartExpirationDate { get; set; }
	    public virtual DateTime EndExpirationDate { get; set; }
	    public virtual DateTime CreateDate { get; set; }
	    public virtual DateTime? ModifiedDate { get; set; }
	    public virtual int AccessLevel { get; set; }
	}

    /// <summary>
    /// A class which represents the OrderPatientView view.
    /// </summary>
	[Table("OrderPatientView")]
	public partial class OrderPatientView
	{
	    public virtual int ID { get; set; }
	    public virtual string OrderNumber { get; set; }
	    public virtual DateTime ExaminationDate { get; set; }
	    public virtual string ProcessingDivision { get; set; }
	    public virtual int InfoID { get; set; }
	    public virtual string ExaminationTypeCode { get; set; }
	    public virtual string ExaminationTypeName { get; set; }
	    public virtual string Comment { get; set; }
	    public virtual string PatientID { get; set; }
	    public virtual string KanjiName { get; set; }
	    public virtual string KanaName { get; set; }
	    public virtual DateTime BirthDate { get; set; }
	    public virtual string Gender { get; set; }
	}

    /// <summary>
    /// A class which represents the View_1 view.
    /// </summary>
	[Table("View_1")]
	public partial class View1
	{
	    public virtual int ID { get; set; }
	    public virtual string OrderNumber { get; set; }
	    public virtual DateTime ExaminationDate { get; set; }
	    public virtual string ProcessingDivision { get; set; }
	    public virtual int InfoID { get; set; }
	    public virtual string ExaminationTypeCode { get; set; }
	    public virtual string ExaminationTypeName { get; set; }
	    public virtual string Comment { get; set; }
	    public virtual string PatientID { get; set; }
	    public virtual string KanjiName { get; set; }
	    public virtual string KanaName { get; set; }
	    public virtual DateTime BirthDate { get; set; }
	    public virtual string Gender { get; set; }
	}

}

