﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace EFCore.TextTemplating.Design
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    internal partial class MyEntityTypeGenerator : MyCodeGeneratorBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.ComponentModel.Dat" +
                    "aAnnotations;\r\n\r\nnamespace ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            this.Write("\r\n{\r\n    public partial class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(EntityType.Name));
            this.Write("\r\n    {\r\n");

    foreach (var property in EntityType.GetProperties().OrderBy(p => p.Scaffolding().ColumnOrdinal))
    {
		if (!property.IsNullable
			&& (!property.ClrType.IsValueType
				|| property.ClrType.IsGenericType
				&& property.ClrType.GetGenericTypeDefinition() == typeof(Nullable<>))
			&& !property.IsPrimaryKey())
		{

            this.Write("\t\t[Required]\r\n");

		}

		var maxLength = property.GetMaxLength();
		if (maxLength.HasValue)
		{
			if (property.ClrType == typeof(string))
			{

            this.Write("\t\t[StringLength(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Literal(maxLength.Value)));
            this.Write(")]\r\n");

			}
			else
			{

            this.Write("\t\t[MaxLength(");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Literal(maxLength.Value)));
            this.Write(")]\r\n");

			}
		}

            this.Write("        public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Code.Reference(property.ClrType)));
            this.Write(" ");
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));
            this.Write(" { get; set; }\r\n\r\n");

    }

	foreach (var navigation in EntityType.GetNavigations())
	{
		var targetTypeName = navigation.GetTargetType().Name;

		if (navigation.IsCollection())
		{

            this.Write("\t\tpublic virtual ICollection<");
            this.Write(this.ToStringHelper.ToStringWithCulture(targetTypeName));
            this.Write("> ");
            this.Write(this.ToStringHelper.ToStringWithCulture(navigation.Name));
            this.Write(" { get; } = new HashSet<");
            this.Write(this.ToStringHelper.ToStringWithCulture(targetTypeName));
            this.Write(">();\r\n\r\n");

		}
		else
		{

            this.Write("\t\tpublic virtual ");
            this.Write(this.ToStringHelper.ToStringWithCulture(targetTypeName));
            this.Write(" ");
            this.Write(this.ToStringHelper.ToStringWithCulture(navigation.Name));
            this.Write(" { get; set; }\r\n\r\n");

		}
	}

            this.Write("    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }

	// TODO: Use paramater directives when compatible with .NET Core
    public IEntityType EntityType { get; private set; }
    public string Namespace { get; private set; }
    public ICSharpHelper Code { get; private set; }

	public void Initialize()
	{
		EntityType = (IEntityType)Session["EntityType"];
		Namespace = (string)Session["Namespace"];
		Code = (ICSharpHelper)Session["Code"];
	}

    }
}