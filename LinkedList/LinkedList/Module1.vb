Module Module1

    Sub Main()

        Dim l As LinkedList

        l.initialize(5)

        l.insertNewData("e")
        l.insertNewData("d")
        l.insertNewData("c")
        l.insertNewData("b")
        l.insertNewData("a")

        l.printList()

        l.deleteNode("b")


        l.printList()

        l.deleteNode("a")

        l.printList()

        l.deleteNode("a")

        l.traceList()

    End Sub

End Module