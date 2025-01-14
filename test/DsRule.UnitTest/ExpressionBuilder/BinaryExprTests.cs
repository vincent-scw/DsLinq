﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using DsRule.ExpressionBuilder;
using DsRule.Tokenizer;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace DsRule.UnitTest.ExpressionBuilder
{
    public class BinaryExprTests
    {
        [Theory]
        [InlineData(Operators.Add, 1, "2", 3)]
        [InlineData(Operators.Subtract, 1, "2", -1)]
        [InlineData(Operators.Add, 1, 1.1d, 2)]
        [InlineData(Operators.Add, 1.1d, 1, 2.1d)]
        [InlineData(Operators.Equal, 1, "1", true)]
        [InlineData(Operators.NotEqual, "2", "2", false)]
        [InlineData(Operators.GreaterThan, 2, "1", true)]
        internal void PrimitiveTest(Operators op, object pLeft, object pRight, object result)
        {
            var bx = new BinaryExpr(op, new ConstantExpr(pLeft), new ConstantExpr(pRight));
            var res = GetResult(bx);
            Assert.Equal(result, res);
        }

        [Theory]
        [InlineData("str1", "str2", "str1str2")]
        [InlineData("str", 1, "str1")]
        internal void StringTest(object pLeft, object pRight, object result)
        {
            var bx = new BinaryExpr(Operators.Add, new ConstantExpr(pLeft), new ConstantExpr(pRight));
            var res = GetResult(bx);
            Assert.Equal(result, res);
        }

        [Theory]
        [InlineData("a", new[] { "a", "b", "c" }, true)]
        [InlineData("d", new[] { "a", "b", "c" }, false)]
        internal void InTest(string pLeft, string[] pList, bool result)
        {
            var arrayExpr = new ArrayExpr(pList.Select(DslExpression.Constant).ToArray(), ExpressionToken.LBracket, ExpressionToken.RBracket);
            var bx = new BinaryExpr(Operators.In, new ConstantExpr(pLeft), arrayExpr);
            var res = GetResult(bx);
            Assert.Equal(result, res);
        }

        private object GetResult(DslExpression expr)
        {
            var lambda = Expression.Lambda(expr.BuildLinqExpression());
            var complied = lambda.Compile();
            return complied.DynamicInvoke();
        }
    }
}
