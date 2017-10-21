Module Module1

    Sub Main()

        Dim l As LinkedList

        l.initialize(20)

        l.insertNewData("i")
        l.insertNewData("h")
        l.insertNewData("g")
        l.insertNewData("f")
        l.insertNewData("e")
        l.insertNewData("d")
        l.insertNewData("c")
        l.insertNewData("b")
        l.insertNewData("a")

        l.recursivePrintList(l.getStartPTR)
        Console.WriteLine("")

        l.reverseList()

        l.recursivePrintList(l.getStartPTR)
        Console.WriteLine("")

        'l.traceList()

        'l.printList()

        'l.deleteNode("b")


        'l.printList()

        'l.deleteNode("a")

        'l.printList()

        'l.deleteNode("a")

        'l.deleteNode("e")

        'l.printList()

        'l.traceList()

    End Sub

End Module