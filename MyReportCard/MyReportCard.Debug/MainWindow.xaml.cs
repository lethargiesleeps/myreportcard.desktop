using System.Windows;
using MyReportCard.Debug.BusinessTests;

namespace MyReportCard.Debug;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    ///     This Window serves to display results of tests as output.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        var builderTests = new BuilderTestUnit();
        var serializeTests = new SerializeTests();

        builderTests.UserBuilderNoTermTest(DebugText); //Passed
        builderTests.UserBuilderWithTerms(DebugText); //Passed
        builderTests.TermBuilderNoCourseTest(DebugText); //Passed
        builderTests.TermBuilderWithCoursesTest(DebugText); //Fail
        builderTests.ComplexTermBuilderTest(DebugText); //Passed
        serializeTests.SerializeTest(DebugText);

    }
}