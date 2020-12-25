using System.Text;
using System.Threading.Tasks;
using Snapshooter.Xunit;
using Xunit;

namespace StrawberryShake.CodeGeneration.CSharp.Tests
{
    public class EntityTypeGenerationTests
    {
        readonly StringBuilder _stringBuilder;
        readonly CodeWriter _codeWriter;
        readonly EntityTypeGenerator _generator;

        public EntityTypeGenerationTests()
        {
            _stringBuilder = new StringBuilder();
            _codeWriter = new CodeWriter(_stringBuilder);
            _generator = new EntityTypeGenerator();
        }

        [Fact]
        public async Task GenerateSimpleClassWithOneValueTypeProperty()
        {
            await _generator.WriteAsync(
                _codeWriter,
                new TypeDescriptor(
                    NamingConventions.EntityTypeNameFromTypeName("Foo"),
                    "FooBarNamespace",
                    new string[] { },
                    new[]
                    {
                        new TypePropertyDescriptor(
                            new TypeReferenceDescriptor(
                                "string",
                                false,
                                ListType.NoList,
                                false
                            ),
                            "SomeText"
                        )
                    }
                )
            );
            _stringBuilder.ToString().MatchSnapshot();
        }

        [Fact]
        public async Task GenerateSimpleClassWithOneReferenceTypeProperty()
        {
            await _generator.WriteAsync(
                _codeWriter,
                new TypeDescriptor(
                    "Foo",
                    "FooBarNamespace",
                    new string[] { },
                    new[]
                    {
                        new TypePropertyDescriptor(
                            new TypeReferenceDescriptor(
                                "Bar",
                                false,
                                ListType.NoList,
                                true
                            ),
                            "Bar"
                        )
                    }
                )
            );
            _stringBuilder.ToString().MatchSnapshot();
        }

        [Fact]
        public async Task GenerateSimpleClassWithMultipleProperties()
        {
            await _generator.WriteAsync(
                _codeWriter,
                new TypeDescriptor(
                    NamingConventions.EntityTypeNameFromTypeName("Foo"),
                    "FooBarNamespace",
                    new string[] { },
                    new[]
                    {
                        new TypePropertyDescriptor(
                            new TypeReferenceDescriptor(
                                "string",
                                false,
                                ListType.NoList,
                                false
                            ),
                            "Id"
                        ),
                        new TypePropertyDescriptor(
                            new TypeReferenceDescriptor(
                                "Bar",
                                false,
                                ListType.List,
                                true
                            ),
                            "Bars"
                        ),
                        new TypePropertyDescriptor(
                            new TypeReferenceDescriptor(
                                "Baz",
                                true,
                                ListType.NoList,
                                true
                            ),
                            "Baz"
                        ),
                    }
                )
            );
            _stringBuilder.ToString().MatchSnapshot();
        }
    }
}
