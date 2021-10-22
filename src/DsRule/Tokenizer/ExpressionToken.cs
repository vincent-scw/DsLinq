﻿using Superpower.Display;

namespace DsRule.Tokenizer
{
    enum ExpressionToken
    {
        None,

        Identifier,

        [Token(Description = "built-in identifier")]
        BuiltInIdentifier,

        String,

        [Token(Description = "regular expression")]
        RegularExpression,

        Number,

        [Token(Description = "hexadecimal number")]
        HexNumber,

        [Token(Example = ",")]
        Comma,

        [Token(Example = ".")]
        Period,

        [Token(Example = "[")]
        LBracket,

        [Token(Example = "]")]
        RBracket,

        [Token(Example = "(")]
        LParen,

        [Token(Example = ")")]
        RParen,

        [Token(Example = "?")]
        QuestionMark,

        [Token(Category = "operator", Example = "+")]
        Plus,

        [Token(Category = "operator", Example = "-")]
        Minus,

        [Token(Example = "*")]
        Asterisk,

        [Token(Category = "operator", Example = "/")]
        ForwardSlash,

        [Token(Category = "operator", Example = "%")]
        Percent,

        [Token(Category = "operator", Example = "^")]
        Caret,

        [Token(Category = "operator", Example = "<")]
        LessThan,

        [Token(Category = "operator", Example = "<=")]
        LessThanOrEqual,

        [Token(Category = "operator", Example = ">")]
        GreaterThan,

        [Token(Category = "operator", Example = ">=")]
        GreaterThanOrEqual,

        [Token(Category = "operator", Example = "=")]
        Equal,

        [Token(Category = "operator", Example = "<>")]
        NotEqual,

        [Token(Category = "keyword", Example = "and")]
        And,

        [Token(Category = "keyword", Example = "in")]
        In,

        [Token(Category = "keyword", Example = "is")]
        Is,

        [Token(Category = "keyword", Example = "like")]
        Like,

        [Token(Category = "keyword", Example = "not")]
        Not,

        [Token(Category = "keyword", Example = "or")]
        Or,

        [Token(Category = "keyword", Example = "true")]
        True,

        [Token(Category = "keyword", Example = "false")]
        False,

        [Token(Category = "keyword", Example = "null")]
        Null,

        [Token(Category = "keyword", Example = "now")]
        Now,

        [Token(Category = "keyword", Example = "today")]
        Today
    }
}
