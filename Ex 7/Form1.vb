Option Strict Off
Option Infer On
Option Explicit Off
'Name: Donut Shoppe
'Purpose: Shop for a variety od donut and coffee options.
'Programmer: Will Young on 3/31

Public Class frmMain
    'Function to do sales tax or whatever'
    Private Function CalcSalesTax(ByVal x As Double)
        Dim dblSalesTax = 0.06D * x
        Math.Round(dblSalesTax, 2)

        Return dblSalesTax
    End Function

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        Dim dblCoffee As Double
        Dim dblDonut As Double
        Dim dblCost As Double
        Dim dblTotal As Double
        Dim dblSales As Double
        'Determine values for coffee and donut values'
        If radGlazed.Checked Then
            dblDonut = 1.05
        ElseIf radFilled.Checked Then
            dblDonut = 1.25
        ElseIf radSugar.Checked Then
            dblDonut = 1.05
        ElseIf radChocolate.Checked Then
            dblDonut = 1.25
        End If

        If radNone.Checked Then
            dblCoffee = 0
        ElseIf radCap.Checked Then
            dblCoffee = 2.75
        ElseIf radReg.Checked Then
            dblCoffee = 1.5
        End If

        dblCost = dblCoffee + dblDonut
        dblSales = CalcSalesTax(dblCost)
        dblTotal = dblCost + dblSales


        lblSubtotal.Text = dblCost.ToString("C2")
        lblSales.Text = dblSales.ToString("C2")
        lblTotal.Text = dblTotal.ToString("C2")
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub

    Private Sub Clearall(sender As Object, e As EventArgs) Handles radSugar.CheckedChanged, radCap.CheckedChanged, radChocolate.CheckedChanged, radFilled.CheckedChanged, radGlazed.CheckedChanged, radNone.CheckedChanged, radReg.CheckedChanged
        lblSales.Text = ""
        lblSubtotal.Text = ""
        lblTotal.Text = ""

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim dlgButton As DialogResult
        dlgButton = MessageBox.Show("Are you sure you want to exit?", "Donuts, not Doughnuts", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dlgButton = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
End Class
