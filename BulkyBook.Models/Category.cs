using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models;

public class Category
{
	public Category()
	{
	}

	//*4 columns* should be created in the Table in the Db

	[Key] // makes the prop a *PRIMARY KEY* and IDENTITY col
	public int Id { get; set; }

	[Required]
	public string Name { get; set; } = "unknown";

	[DisplayName("Display Order")]
	[Range(1,100,ErrorMessage = "The range must be between 1 and 100")]
	public int DisplayOrder { get; set; }

	public DateTime CreatedDateTime { get; set; } = DateTime.Now;
	// a) To set default value, b) when an obj of this class is created, this is set as the default value

}

