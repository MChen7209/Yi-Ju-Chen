echo SVN revision %SVN_REVISION%, Jenkins build %BUILD_NUMBER%
set PATH=C:\programs\ruby\ruby220\bin;%PATH%
set PATH=C:\programs\phantomjs-1.9.7\;%PATH%
@echo on
call bundle install
@echo on
call bundle exec rake jenkins
exit %ERRORLEVEL%
