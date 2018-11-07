Public Function CommissionRate(age As Integer, ByRef product As Range) As String

    '////   initiate variables for first product test ////
    Dim rng1, rng2, rng3, offsetRange As Range
    Dim firstProductTest, secondProductTest As Range
    Dim wksSource As Worksheet
    Dim wksdest As Worksheet

   
    Dim printOut As String
    
    Dim ageRanges As Integer
    Dim address As String
    Dim productAddress As String
    
 
    Dim forLoopRowOffsetCounter, ageMin, ageMax As Integer
    forLoopRowOffsetCounter = 0
    
    '////  set worksheet & range variables ////
    '@@ age = wksSource.Range("d4").Value
    '@@ modified with age input
    Set wksSource = ActiveWorkbook.Sheets(1)
    Set wksdest = ActiveWorkbook.Sheets(2)
    '@@ Set rng1 = wksSource.Range("o3")
    '@@ Modified for product input
    Set rng1 = wksSource.Range(productAddress)
    '@@ Set rng2 = wksdest.Range("I3:I39")
    '@@ modified with rngSellingProducts input
    Set rng2 = wksdest.Range("rngSellingProducts")
    Set rng3 = wksdest.Range("I3:I39")

    productAddress = product.address
   
    

    '////   Initiate first product test ////
    Set firstProductTest = rng2.Find(rng1)
    address = firstProductTest.address
    
    '//// Test if product is the selling product table  ////
    If firstProductTest Is Nothing Then
        Debug.Print "product (" + CStr(product.Value) + ") is not in the selling product table"
    Else
        Set secondProductTest = rng3.Find(rng1)
        address = secondProductTest.address
        Debug.Print secondProductTest.address
    End If
    
    Set offsetRange = wksdest.Range(address)
    ageRanges = offsetRange.Offset(1, 0)
    Debug.Print "AgeRanges: " + CStr(ageRanges)
    For i = 1 To ageRanges
        Debug.Print "This is turn " + CStr(i) + " through the loop"
        ageMin = offsetRange.Offset(forLoopRowOffsetCounter, 3)
        Debug.Print "Age: " + CStr(age) + "AgeMin: " + CStr(ageMin)
        ageMax = offsetRange.Offset(forLoopRowOffsetCounter, 4)
        Debug.Print "Age: " + CStr(age) + "AgeMax: " + CStr(ageMax)
        If age > ageMin And age < ageMax Then
            Debug.Print TypeName(offsetRange.Offset(forLoopRowOffsetCounter, 5))
            Debug.Print "the Commission Rate is :" + CStr(CommissionRate)
            CommissionRate = CStr(CommissionRate)
            Exit For
        Else
            If i = ageRanges Then
                printOut = "Age outside the limit"
                Debug.Print printOut
                josh = printOut
            End If
            
            forLoopRowOffsetCounter = forLoopRowOffsetCounter + 1
        End If
        
    Next i
    
    'If rngSellingProducts.Find(Product) Then a = var2
    
End Function


