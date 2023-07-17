Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Office.Utils
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.Services
Imports System.Linq
Imports System.Text.RegularExpressions

Namespace RichEditSyntaxSample
    Public Class CustomSyntaxHighlightService
        Implements ISyntaxHighlightService

        Private ReadOnly document As Document

        Private _keywords As Regex
        Private _keywords_Functions As Regex
        Private _quotedString As New Regex("'([^']|'')*'")
        'Private _commentedString As New Regex("(/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/|\--[a-zA-Z0-9._%+-@öäüÖÄÜ?=()\\p{all}\h\[\]]{0,}|\--+)")
        Private _commentedString As New Regex("\--[a-zA-Z0-9._%*<>+-@öäüÖÄÜ?=()\\p{all}\. \[\]]{0,}")

        Public Sub New(ByVal document As Document)
            Me.document = document
            Me.document.DefaultCharacterProperties.FontName = "Consolas"
            Dim keywords() As String = {"UNION", "FULL OUTER JOIN", "RIGHT JOIN", "LEFT JOIN", "INNER JOIN", "DROP", "AS", "DELETE", "INSERT", "SELECT", "CREATE", "TABLE", "USE", "IDENTITY", "ON", "OFF", "NOT", "NULL", "WITH", "SET", "GO", "DECLARE", "EXECUTE", "NVARCHAR", "FROM", "INTO", "VALUES", "WHERE", "AND", "WHILE", "BEGIN", "END", "IF" _
                                       , "Union", "full outer join", "right join", "left join", "inner join", "drop", "As", "Delete", "Insert", "Select", "Create", "Table", "Use", "Identity", "On", "Off", "Not", "Null", "With", "Set", "Go", "Declare", "Execute", "Nvarchar", "From", "Into", "Values", "Where", "And", "While", "Begin", "End", "If" _
                                       , "as", "delete", "insert", "select", "create", "table", "use", "identity", "on", "off", "not", "null", "with", "set", "go", "declare", "execute", "nvarchar", "from", "into", "values", "where", "and", "while", "begin", "end", "if" _
                                       , "datetime", "float", "varchar", "bit", "int", "char", "nchar", "ntext", "money", "numeric", "decimal" _
                                       , "Datetime", "Float", "Varchar", "Bit", "Int", "Char", "Nchar", "Ntext", "Money", "Numeric", "Decimal" _
                                       , "DATETIME", "FLOAT", "VARCHAR", "BIT", "INT", "CHAR", "NCHAR", "NTEXT", "MONEY", "NUMERIC", "DECIMAL" _
                                       , "FIRSTROW", "CODEPAGE", "DATAFILETYPE", "FIELDTERMINATOR", "ROWTERMINATOR", "TABLOCK", "KEEPNULLS", "bulk", "Bulk", "BULK" _
                                       , "firstrow", "Firstrow", "codepage", "Codepage", "datafiletype", "Datafiletype", "fieldterminator", "Fieldterminator", "tablock", "Tablock", "keepnulls", "Keepnulls" _
                                       , "truncate", "Truncate", "TRUNCATE", "alter", "Alter", "ALTER", "add", "Add", "ADD", "case", "Case", "CASE", "when", "When", "WHEN", "then", "Then", "THEN" _
                                       , "else", "Else", "ELSE", "GROUP BY", "Group By", "group by", "ORDER BY", "Order By", "order by", "OVER", "Over", "over", "OR", "Or", "or", "LIKE", "like", "Like", "TOP", "top", "Top" _
                                       , "distinct", "Distinct", "DISTINCT", "rank", "Rank", "RANK", "partion by", "Partition By", "PARTITION BY", "exec", "EXEC", "Exec"}
            Me._keywords = New Regex("\b(" & String.Join("|", keywords.Select(Function(w) Regex.Escape(w))) & ")\b")
            'SQL Functions
            Dim keywords_Functions() As String = {"convert", "Convert", "CONVERT", "replace", "Replace", "REPLACE", "len", "Len", "LEN", "update", "Update", "UPDATE", "max", "Max", "MAX" _
                                                  , "min", "Min", "MIN", "abs", "Abs", "ABS", "round", "Round", "ROUND", "avg", "Avg", "AVG", "cast", "Cast", "CAST", "ceiling", "Ceiling", "CEILING" _
                                                  , "str", "Str", "STR", "ltrim", "Ltrim", "LTRIM", "rtrim", "Rtrim", "RTRIM", "substring", "Substring", "SUBSTRING", "left", "Left", "LEFT" _
                                                  , "right", "Right", "RIGHT", "stuff", "Stuff", "STUFF", "sum", "Sum", "SUM", "count", "Count", "COUNT", "dateadd", "Dateadd", "DATEADD", "datediff", "Datediff", "DATEDIFF", "DATEFROMPARTS", "Datefromparts", "datefromparts" _
                                                  , "datename", "Datename", "DATENAME", "datepart", "Datepart", "DATEPART", "coalesce", "Coalesce", "COALESCE", "isdate", "Isdate", "ISDATE", "isnull", "Isnull", "ISNULL" _
                                                  , "isnumeric", "Isnumeric", "ISNUMERIC", "lower", "Lower", "LOWER", "upper", "Upper", "UPPER", "floor", "Floor", "FLOOR", "day", "Day", "DAY" _
                                                  , "month", "Month", "MONTH", "year", "Year", "YEAR", "getdate", "Getdate", "GETDATE", "char", "Char", "CHAR", "COLLATE", "Collate", "collate", "ROW_NUMBER", "Row_Number", "row_number" _
                                                  , "format", "Format", "FORMAT"}
            Me._keywords_Functions = New Regex("\b(" & String.Join("|", keywords_Functions.Select(Function(w) Regex.Escape(w))) & ")\b")
        End Sub
        Public Sub ForceExecute() Implements ISyntaxHighlightService.ForceExecute
            Execute()
        End Sub
        Public Sub Execute() Implements ISyntaxHighlightService.Execute
            Dim tSqltokens As List(Of SyntaxHighlightToken) = ParseTokens()
            document.ApplySyntaxHighlight(tSqltokens)
        End Sub

        Private Function ParseTokens() As List(Of SyntaxHighlightToken)
            Dim tokens As New List(Of SyntaxHighlightToken)()
            Dim ranges() As DocumentRange = Nothing

            ' search for quoted strings
            ranges = document.FindAll(_quotedString)
            For i As Integer = 0 To ranges.Length - 1
                tokens.Add(CreateToken(ranges(i).Start.ToInt(), ranges(i).End.ToInt(), Color.Red))
            Next i

            'Search for comments
            ranges = document.FindAll(_commentedString)
            For i As Integer = 0 To ranges.Length - 1
                tokens.Add(CreateToken(ranges(i).Start.ToInt(), ranges(i).End.ToInt(), Color.Green))
            Next i

            'Extract all keywords
            ranges = document.FindAll(_keywords)
            For j As Integer = 0 To ranges.Length - 1
                If Not IsRangeInTokens(ranges(j), tokens) Then
                    tokens.Add(CreateToken(ranges(j).Start.ToInt(), ranges(j).End.ToInt(), Color.Blue))
                End If
            Next j

            'Find all SQL Functions
            ranges = document.FindAll(_keywords_Functions)
            For j As Integer = 0 To ranges.Length - 1
                If Not IsRangeInTokens(ranges(j), tokens) Then
                    tokens.Add(CreateToken(ranges(j).Start.ToInt(), ranges(j).End.ToInt(), Color.DeepPink))
                End If
            Next j

            'Find all comments
            ranges = document.FindAll(_commentedString)
            For j As Integer = 0 To ranges.Length - 1
                If Not IsRangeInTokens(ranges(j), tokens) Then
                    tokens.Add(CreateToken(ranges(j).Start.ToInt(), ranges(j).End.ToInt(), Color.Green))
                End If
            Next j

            ' order tokens by their start position
            tokens.Sort(New SyntaxHighlightTokenComparer())

            ' fill in gaps in document coverage
            tokens = CombineWithPlainTextTokens(tokens)
            Return tokens
        End Function

        'Parse the remaining text into tokens:
        Private Function CombineWithPlainTextTokens(ByVal tokens As List(Of SyntaxHighlightToken)) As List(Of SyntaxHighlightToken)
            Dim result As New List(Of SyntaxHighlightToken)(tokens.Count * 2 + 1)
            Dim documentStart As Integer = Me.document.Range.Start.ToInt()
            Dim documentEnd As Integer = Me.document.Range.End.ToInt()
            If tokens.Count = 0 Then
                result.Add(CreateToken(documentStart, documentEnd, Color.Black))
            Else
                Dim firstToken As SyntaxHighlightToken = tokens(0)
                If documentStart < firstToken.Start Then
                    result.Add(CreateToken(documentStart, firstToken.Start, Color.Black))
                End If
                result.Add(firstToken)
                For i As Integer = 1 To tokens.Count - 1
                    Dim token As SyntaxHighlightToken = tokens(i)
                    Dim prevToken As SyntaxHighlightToken = tokens(i - 1)
                    If prevToken.End <> token.Start Then
                        result.Add(CreateToken(prevToken.End, token.Start, Color.Black))
                    End If
                    result.Add(token)
                Next i
                Dim lastToken As SyntaxHighlightToken = tokens(tokens.Count - 1)
                If documentEnd > lastToken.End Then
                    result.Add(CreateToken(lastToken.End, documentEnd, Color.Black))
                End If
            End If
            Return result
        End Function

        'Create a token from the retrieved range and specify its forecolor
        Private Function CreateToken(ByVal start As Integer, ByVal [end] As Integer, ByVal foreColor As Color) As SyntaxHighlightToken
            Dim properties As New SyntaxHighlightProperties()
            properties.ForeColor = foreColor
            Return New SyntaxHighlightToken(start, [end] - start, properties)
        End Function

        'Check whether tokens intersect each other
        Private Function IsRangeInTokens(ByVal range As DocumentRange, ByVal tokens As List(Of SyntaxHighlightToken)) As Boolean
            Return tokens.Any(Function(t) IsIntersect(range, t))
        End Function
        Private Function IsIntersect(ByVal range As DocumentRange, ByVal token As SyntaxHighlightToken) As Boolean
            Dim start As Integer = range.Start.ToInt()
            If start >= token.Start AndAlso start < token.End Then
                Return True
            End If
            Dim [end] As Integer = range.End.ToInt() - 1
            If [end] >= token.Start AndAlso [end] < token.End Then
                Return True
            End If
            If start < token.Start AndAlso [end] >= token.End Then
                Return True
            End If
            Return False
        End Function
    End Class

    'Compare token's initial positions to sort them
    Public Class SyntaxHighlightTokenComparer
        Implements IComparer(Of SyntaxHighlightToken)

        Public Function Compare(ByVal x As SyntaxHighlightToken, ByVal y As SyntaxHighlightToken) As Integer Implements IComparer(Of SyntaxHighlightToken).Compare
            Return x.Start - y.Start
        End Function
    End Class
End Namespace

