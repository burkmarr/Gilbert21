Public Class clsPolygon

    Private ReadOnly _vertices As PointF()

    ''' <summary>
    '''		Creates a new instance of the <see cref="clsPolygon"/> class with the specified vertices.
    ''' </summary>
    ''' <param name="vertices">
    '''		An array of <see cref="PointF"/> structures representing the points between the sides of the polygon.
    ''' </param>
    Public Sub New(ByVal vertices As PointF())
        _vertices = vertices
    End Sub

    ''' <summary>
    '''		Determines if the specified <see cref="PointF"/> if within this polygon.
    ''' </summary>
    ''' <remarks>
    '''		This algorithm is extremely fast, which makes it appropriate for use in brute force algorithms.
    ''' </remarks>
    ''' <param name="point">
    '''		The point containing the x,y coordinates to check.
    ''' </param>
    ''' <returns>
    '''		<c>true</c> if the point is within the polygon, otherwise <c>false</c>
    ''' </returns>
    Public Function PointInPolygon(ByVal point As PointF) As Boolean
        Dim j = _vertices.Length - 1
        Dim oddNodes = False

        For i As Integer = 0 To _vertices.Length - 1
            If _vertices(i).Y < point.Y AndAlso _vertices(j).Y >= point.Y OrElse _vertices(j).Y < point.Y AndAlso _vertices(i).Y >= point.Y Then
                If _vertices(i).X + (point.Y - _vertices(i).Y) / (_vertices(j).Y - _vertices(i).Y) * (_vertices(j).X - _vertices(i).X) < point.X Then
                    oddNodes = Not oddNodes
                End If
            End If
            j = i
        Next

        Return oddNodes
    End Function
End Class
