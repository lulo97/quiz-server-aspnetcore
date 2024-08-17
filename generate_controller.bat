@echo off

setlocal enabledelayedexpansion

set models=Achievement Answer Comment CommentVote DifficultLevel EducationLevel Favourite Follow Language Notification Play PlayPoint Point Question QuestionType Quiz QuizQuestion Rating Report ReportReason ReportTarget Room SelectedAnswer Subject SubSubject Time User UserRoom

for %%m in (%models%) do (
    echo Generating controller for %%m
    dotnet aspnet-codegenerator controller -name %%mController -async -api -m %%m -dc ApplicationDbContext -outDir Controllers
)

echo Done!
pause
