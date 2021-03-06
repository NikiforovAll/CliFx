﻿using System;
using System.Collections;
using System.Collections.Generic;
using CliFx.Attributes;

namespace CliFx.Tests.Commands
{
    [Command("cmd")]
    public partial class UnsupportedArgumentTypesCommand : SelfSerializeCommandBase
    {
        [CommandOption("str-non-initializable")]
        public CustomType? StringNonInitializable { get; set; }

        [CommandOption("str-enumerable-non-initializable")]
        public CustomEnumerable<string>? StringEnumerableNonInitializable { get; set; }
    }

    public partial class UnsupportedArgumentTypesCommand
    {
        public class CustomType
        {
        }

        public class CustomEnumerable<T> : IEnumerable<T>
        {
            public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>) Array.Empty<T>()).GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}