using System.Collections.Generic;

namespace StrawberryShake.CodeGeneration
{
    public class TypeDescriptor
        : ICodeDescriptor
    {
        /// <summary>
        /// Gets the .NET type name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The properties that result from the requested fields of the operation this ResultType is generated for.
        /// </summary>
        public IReadOnlyList<TypePropertyDescriptor> Properties { get; }

        /// <summary>
        /// A list of interface names the ResultType implements
        /// </summary>
        public IReadOnlyList<string> Implements { get; }

        /// <summary>
        /// The name of the namespace the generated type shall reside in
        /// </summary>
        public string Namespace { get; }

        public TypeDescriptor(
            string name,
            string @namespace,
            IReadOnlyList<string> implements,
            IReadOnlyList<TypePropertyDescriptor> properties)
        {
            Name = name;
            Properties = properties;
            Namespace = @namespace;
            Implements = implements;
        }
    }
}
