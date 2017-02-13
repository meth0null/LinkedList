'Implementation of Linked Lists using an Arrays

Module Module1

    Public Structure listNode

        Dim data As String
        Dim ptr As Integer

    End Structure

    Public Structure LinkList
        Const NullPointer = -1

        Dim startPTR As Integer
        Dim freeListPTR As Integer

        Dim list() As listNode

        Sub initializeList(ByVal size As Integer)

            'need to set the size of the list to a variable
            ReDim list(size - 1)

            startPTR = NullPointer
            freeListPTR = 0

            For i = 0 To size - 2
                list(i).data = ""
                list(i).ptr = i + 1
            Next

            list(size - 1).data = ""
            list(size - 1).ptr = NullPointer

        End Sub

        Sub insertNewNode(ByVal newItem As String)
            'Inserting a new node into an ordered linked list

            If freeListPTR = NullPointer Then
                Console.WriteLine("No more room in list")
            Else

                'Create a new pointer and set it to freePTR
                'This pointer will be used to refer to new node until it has put it proper place
                Dim newNodePointer As Integer = freeListPTR

                list(newNodePointer).data = newItem 'Set new item to data part of new node
                freeListPTR = list(freeListPTR).ptr 'Make freePTR point to next available free node

                'Crate a new temp pointer that can move through the list
                'Create a new pointer that holds the previously visitied node

                Dim thisNodePTR As Integer
                Dim previousNodePTR As Integer

                'Assign newly created pointers to starting points

                thisNodePTR = startPTR
                previousNodePTR = startPTR


                If startPTR = NullPointer Then
                    list(newNodePointer).ptr = NullPointer
                    startPTR = newNodePointer

                ElseIf newItem < list(startPTR).data Then
                    list(newNodePointer).ptr = startPTR
                    startPTR = newNodePointer
                Else

                    While thisNodePTR <> NullPointer
                        If list(thisNodePTR).data < newItem Then
                            previousNodePTR = thisNodePTR
                            thisNodePTR = list(thisNodePTR).ptr

                        Else
                            thisNodePTR = list(thisNodePTR).ptr


                        End If

                    End While

                    If list(previousNodePTR).ptr = NullPointer Then
                        list(previousNodePTR).ptr = newNodePointer
                        list(newNodePointer).ptr = NullPointer
                    Else

                        list(newNodePointer).ptr = list(previousNodePTR).ptr
                        list(previousNodePTR).ptr = newNodePointer

                    End If

                End If


                ''This while loop will traverse through the list until thisNodePTR hits NullPointer
                ''This section of code will place the new item in proper place, for Ordered Lists

                'While thisNodePTR <> NullPointer

                '    'If statement checks if the current node contains data smaller that the new item
                '    'If true set previousNodePTR to thisNodePTR and set thisNodePTR to point
                '    'to the next node in the list

                '    'Else just make thisNodePTR point to the next node in the list until it hits NullPointer
                '    If list(thisNodePTR).data < newItem Then
                '        previousNodePTR = thisNodePTR
                '        thisNodePTR = list(thisNodePTR).ptr

                '    Else
                '        thisNodePTR = list(thisNodePTR).ptr


                '    End If

                'End While

                'If previousNodePTR = startPTR Then
                '    'If the new node needs to go at the start of the list
                '    'Make new node point to the next node through previousNodePTR
                '    'Make the startPTR point to the new node
                '    list(newNodePointer).ptr = previousNodePTR
                '    startPTR = newNodePointer

                'Else

                '    'Need to set node somewhere in the middle 
                '    list(newNodePointer).ptr = list(previousNodePTR).ptr
                '    list(previousNodePTR).ptr = newNodePointer


                'End If
            End If

        End Sub

        Sub deleteNode(ByVal dataItem As String)

            'This won't work

            If startPTR = NullPointer Then
                Console.WriteLine("There are no nodes in the list")

            Else

                Dim thisNodePTR As Integer = searchList(dataItem)

                If thisNodePTR = NullPointer Then
                    Console.WriteLine("The data to be deleted does not exist in list")
                Else
                    If thisNodePTR = startPTR Then
                        startPTR = list(thisNodePTR).ptr
                        list(thisNodePTR).ptr = freeListPTR
                        freeListPTR = thisNodePTR

                    ElseIf list(thisNodePTR).ptr = NullPointer Then
                        'Write code here,

                    End If
                End If

            End If


        End Sub

        Sub printList()
            If startPTR = NullPointer Then
                Console.WriteLine("There are no nodes in the list")
            Else
                Dim thisnodePTR As Integer = startPTR

                While thisnodePTR <> NullPointer
                    Console.Write(list(thisnodePTR).data & " ")
                    thisnodePTR = list(thisnodePTR).ptr
                End While
                Console.WriteLine("")
            End If

        End Sub

        Function searchList(ByVal key As String)

            If startPTR = NullPointer Then
                Console.WriteLine("No nodes in the list")
                Return NullPointer
            Else
                Dim thisNodePTR As Integer
                thisNodePTR = startPTR

                While thisNodePTR <> NullPointer
                    If list(thisNodePTR).data = key Then
                        Return thisNodePTR
                    End If

                    thisNodePTR = list(thisNodePTR).ptr

                End While

                Return NullPointer

            End If
        End Function

    End Structure









    Sub Main()

        Dim l As LinkList

        l.initializeList(5)
        l.insertNewNode("B")
        l.insertNewNode("D")
        l.insertNewNode("C")
        l.insertNewNode("A")
        l.insertNewNode("E")


        l.printList()

        Console.WriteLine(l.searchList("A"))
        Console.WriteLine(l.searchList("B"))
        Console.WriteLine(l.searchList("C"))
        Console.WriteLine(l.searchList("D"))
        Console.WriteLine(l.searchList("E"))
        'l.printArrayList()


    End Sub

End Module
