pipeline {
  agent {
    node {
      label 'DotNet'
    }
    
  }
  stages {
    stage('') {
      steps {
        sh '''cd /var/lib/jenkins/workspace/src/CityInfoApi/CityInfo.Data/
dotnet restore;
dotnet build;'''
      }
    }
  }
}