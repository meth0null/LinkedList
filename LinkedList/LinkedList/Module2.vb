Module Module2

    Public Structure LinkedList

        Public Structure ListNode
            Dim DATA As String
            Dim PTR As Integer
        End Structure

        Private Const NullPTR = -1

        Private startPTR As Integer
        Private freeListPTR As Integer

        Function getStartPTR() As Integer
            Return startPTR
        End Function

        Dim list() As ListNode

        Sub initialize(ByVal size As Integer)
            startPTR = NullPTR
            freeListPTR = 0

            ReDim list(size - 1)

            For i = 0 To size - 2
                list(i).DATA = ""
                list(i).PTR = i + 1
            Next

            list(size - 1).DATA = ""
            list(size - 1).PTR = NullPTR
        End Sub

        Sub insertNewData(ByVal dataItem As String)

            If freeListPTR = NullPTR Then
                Console.WriteLine("No more space in the list")
            Else
                Dim newNodePTR As Integer
                newNodePTR = freeListPTR
                list(newNodePTR).DATA = dataItem
                freeListPTR = list(newNodePTR).PTR

                If startPTR = NullPTR Then
                    list(newNodePTR).PTR = NullPTR
                    startPTR = newNodePTR
                    Exit Sub
                End If

                If list(newNodePTR).DATA < list(startPTR).DATA Then
                    list(newNodePTR).PTR = startPTR
                    startPTR = newNodePTR
                    Exit Sub
                End If

                Dim TNP As Integer = startPTR 'thisNodePointer
                Dim PNP As Integer = NullPTR 'previousNodePointer

                While TNP <> NullPTR
                    If list(TNP).DATA < dataItem Then
                        PNP = TNP
                        TNP = list(TNP).PTR
                    Else
                        TNP = list(TNP).PTR

                    End If

                End While

                If list(PNP).PTR = NullPTR Then
                    list(PNP).PTR = newNodePTR
                    list(newNodePTR).PTR = NullPTR
                    Exit Sub
                End If

                list(newNodePTR).PTR = list(PNP).PTR
                list(PNP).PTR = newNodePTR



            End If


        End Sub

        Sub deleteNode(ByVal dataItem As String)

            If startPTR = NullPTR Then
                Console.WriteLine("There are no nodes in the list")
                Exit Sub
            End If

            Dim TNP As Integer = startPTR
            Dim PNP As Integer = NullPTR

            'Loop to find where in the list the item to be deleted is
            While TNP <> NullPTR
                If list(TNP).DATA = dataItem Then
                    Exit While
                Else
                    PNP = TNP
                    TNP = list(TNP).PTR
                End If
            End While

            'The node to be deleted was not found
            If TNP = NullPTR Then
                Console.WriteLine("The node to be delete is not in the list")
                Exit Sub
            End If

            'The node to be deleted is at the start of the list
            If TNP = startPTR And PNP = NullPTR Then
                startPTR = list(TNP).PTR
                list(TNP).PTR = freeListPTR
                list(TNP).DATA = ""
                freeListPTR = TNP
                Exit Sub
            End If

            'The node to be deleted is at the end of the list
            If list(TNP).PTR = NullPTR Then
                list(PNP).PTR = NullPTR
                list(TNP).PTR = freeListPTR
                list(TNP).DATA = ""
                freeListPTR = TNP
                Exit Sub
            End If

            'The node to be deleted is soemwhere in the middle of the list
            list(PNP).PTR = list(TNP).PTR
            list(TNP).PTR = freeListPTR
            list(TNP).DATA = ""
            freeListPTR = TNP

        End Sub

        Sub printList()
            Dim TNP As Integer = startPTR

            While TNP <> NullPTR
                Console.Write(list(TNP).DATA & " ")
                TNP = list(TNP).PTR
            End While

            Console.WriteLine("")


        End Sub

        Sub recursivePrintList(ByVal ptr As Integer)
            If ptr = NullPTR Then
                Return
            End If

            Console.Write(list(ptr).DATA & " ")
            recursivePrintList(list(ptr).PTR)
        End Sub

        Sub traceList()
            'This subroutine basically prints all the nodes along with pointer information

            If startPTR = NullPTR Then
                Console.WriteLine("There are no nodes in the list")
                Exit Sub
            End If

            Console.WriteLine("Start pionter: " & startPTR)
            Console.WriteLine("Free list pointer: " & freeListPTR)

            Dim thisNodePTR As Integer = startPTR

            While thisNodePTR <> NullPTR
                Console.WriteLine("Node: " & thisNodePTR &
                                  " Data: " & list(thisNodePTR).DATA &
                                  " Points to: " & list(thisNodePTR).PTR)
                thisNodePTR = list(thisNodePTR).PTR
            End While


        End Sub

        Function searchList(ByVal key As String)

            If startPTR = NullPTR Then
                Console.WriteLine("No nodes in the list")
                Return NullPTR
            Else
                Dim thisNodePTR As Integer
                thisNodePTR = startPTR

                While thisNodePTR <> NullPTR
                    If list(thisNodePTR).DATA = key Then
                        Return thisNodePTR
                    End If

                    thisNodePTR = list(thisNodePTR).PTR

                End While

                Return NullPTR

            End If
        End Function

        Sub reverseList()

            If startPTR = NullPTR Then
                Return
            End If

            Dim current, prev, nxt As Integer

            current = startPTR
            prev = NullPTR

            While current <> NullPTR
                nxt = list(current).PTR
                list(current).PTR = prev
                prev = current
                current = nxt
            End While

            startPTR = prev

        End Sub

    End Structure

End Module
