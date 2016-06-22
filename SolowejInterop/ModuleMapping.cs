using System;
using System.Linq;

namespace LibSolowej
{
	public static class AttributeExtensions
	{
		public static TValue GetAttributeValue<TAttribute, TValue>(
			this Type type, 
			Func<TAttribute, TValue> valueSelector) 
			where TAttribute : Attribute
		{
			var att = type.GetCustomAttributes(
				typeof(TAttribute), true
			).FirstOrDefault() as TAttribute;
			if (att != null)
			{
				return valueSelector(att);
			}
			return default(TValue);
		}
	}

	public enum ModuleTypes
	{
		Generator,
		Modifier
	}

	public class ModuleMappingAttribute : System.Attribute
	{
		public ModuleTypes ModuleType 	{ get; private set; }
		public string ModuleName 		{ get;private set; }

		public ModuleMappingAttribute(ModuleTypes moduleType, string moduleName)
		{
			ModuleType = moduleType;
			ModuleName = moduleName;
		}
	}
}

