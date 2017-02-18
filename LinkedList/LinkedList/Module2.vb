Module Module2

    Public Structure LinkedList

        Public Structure ListNode
            Dim DATA As String
            Dim PTR As Integer
        End Structure

        Private Const NullPTR = -1

        Private startPTR As Integer
        Private freeListPTR As Integer

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

            Dim thisNodePTR As Integer = startPTR
            Dim previousNodePTR As Integer = NullPTR

            'Deleting the first element
            If dataItem = list(startPTR).DATA Then
                startPTR = list(thisNodePTR).PTR
                list(thisNodePTR).PTR = freeListPTR
                freeListPTR = thisNodePTR
                Exit Sub
            End If

            While thisNodePTR <> NullPTR

                If list(thisNodePTR).DATA = dataItem Then
                    Exit While

                Else
                    previousNodePTR = thisNodePTR
                    thisNodePTR = list(thisNodePTR).PTR

                End If
            End While

            If list(previousNodePTR).PTR = NullPTR Then
                Console.WriteLine("The node to be deleted does not exist")
                Exit Sub
            End If

            Dim tempPTR As Integer = list(previousNodePTR).PTR

            'Deleting the last element
            If list(tempPTR).PTR = NullPTR Then
                list(tempPTR).PTR = freeListPTR
                freeListPTR = tempPTR
                list(previousNodePTR).PTR = NullPTR
                Exit Sub
            End If

            'Deleting somewhere in the middle element
            list(previousNodePTR).PTR = list(tempPTR).PTR
            list(tempPTR).PTR = freeListPTR
            freeListPTR = tempPTR

        End Sub

        Sub printList()
            Dim TNP As Integer = startPTR

            While TNP <> NullPTR
                Console.Write(list(TNP).DATA & " ")
                TNP = list(TNP).PTR
            End While

            Console.WriteLine("")


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

    End Structure

End Module
