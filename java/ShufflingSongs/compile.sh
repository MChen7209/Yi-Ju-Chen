    /bin/rm -rf classes
    mkdir classes

    export JUNIT_JAR="/opt/java/junit/junit-4.12.jar"

    cd ./ShuffleSongs.java
    
    javac -Xlint:deprecation -Xlint:unchecked -d classes -classpath classes: *.java
    java -classpath classes: ShuffleSongs
