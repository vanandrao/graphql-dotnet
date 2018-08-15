using System;
using GraphQL.Language.AST;

namespace GraphQL.Types
{
    public class DateTimeOffsetGraphType : ScalarGraphType
    {
        public DateTimeOffsetGraphType()
        {
            Name = "DateTimeOffset";
            Description =
                "The `DateTimeOffset` scalar type represents a date, time and offset from UTC. `DateTimeOffset` expects timestamps " +
                "to be formatted in accordance with the [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard.";
        }

        public override object Serialize(object value)
        {
            return ParseValue(value);
        }

        public override object ParseValue(object value)
        {
            return ValueConverter.ConvertTo(value, typeof(DateTimeOffset));
        }

        public override object ParseLiteral(IValue value)
        {
            if (value is DateTimeOffsetValue offsetValue)
            {
                return ParseValue(offsetValue.Value);
            }

            if (value is StringValue stringValue)
            {
                return ParseValue(stringValue.Value);
            }

            return null;
        }
    }
}
