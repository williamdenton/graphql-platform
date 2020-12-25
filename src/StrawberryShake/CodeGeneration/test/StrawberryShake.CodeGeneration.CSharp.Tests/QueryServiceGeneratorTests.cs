using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Snapshooter.Xunit;
using Xunit;

namespace StrawberryShake.CodeGeneration.CSharp.Tests
{
    public class QueryServiceGeneratorTests
    {
        readonly StringBuilder _stringBuilder;
        readonly CodeWriter _codeWriter;
        readonly OperationServiceGenerator _generator;

        public QueryServiceGeneratorTests()
        {
            _stringBuilder = new StringBuilder();
            _codeWriter = new CodeWriter(_stringBuilder);
            _generator = new OperationServiceGenerator();
        }

        [Fact]
        public async Task GenerateQueryServiceWithoutArguments()
        {
            await _generator.WriteAsync(
                _codeWriter,
                new QueryOperationDescriptor(
                    new TypeReferenceDescriptor(
                        "Foo",
                        false,
                        ListType.NoList,
                        true
                    ),
                    new Dictionary<string, TypeReferenceDescriptor>()
                )
            );

            _stringBuilder.ToString().MatchSnapshot();
        }

        [Fact]
        public async Task GenerateQueryServiceWithValueArgument()
        {
            await _generator.WriteAsync(
                _codeWriter,
                new QueryOperationDescriptor(
                    new TypeReferenceDescriptor(
                        "Foo",
                        false,
                        ListType.NoList,
                        true
                    ),
                    new Dictionary<string, TypeReferenceDescriptor>()
                    {
                        {"name", new TypeReferenceDescriptor("string", false, ListType.NoList, false)}
                    }
                )
            );

            _stringBuilder.ToString().MatchSnapshot();
        }

        [Fact]
        public async Task GenerateQueryServiceWithReferenceArgument()
        {
            await _generator.WriteAsync(
                _codeWriter,
                new QueryOperationDescriptor(
                    new TypeReferenceDescriptor(
                        "Foo",
                        false,
                        ListType.NoList,
                        true
                    ),
                    new Dictionary<string, TypeReferenceDescriptor>()
                    {
                        {"bar", new TypeReferenceDescriptor("BarInput", true, ListType.NoList, true)}
                    }
                )
            );

            _stringBuilder.ToString().MatchSnapshot();
        }

        [Fact]
        public async Task GenerateQueryServiceWithArguments()
        {
            await _generator.WriteAsync(
                _codeWriter,
                new QueryOperationDescriptor(
                    new TypeReferenceDescriptor(
                        "Foo",
                        false,
                        ListType.NoList,
                        true
                    ),
                    new Dictionary<string, TypeReferenceDescriptor>()
                    {
                        {"name", new TypeReferenceDescriptor("string", false, ListType.NoList, false)},
                        {"a", new TypeReferenceDescriptor("BarInput", true, ListType.NoList, true)}
                    }
                )
            );

            _stringBuilder.ToString().MatchSnapshot();
        }
    }
}
