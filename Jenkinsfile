node('docker') {
 
    stage 'Checkout'
        checkout scm
    stage 'Build & UnitTest' 
        sh "docker build -t mysql-mine -f Dockerfile.MySql ."
        sh "docker build -t accountownerapp:B${BUILD_NUMBER} -f Dockerfile ."
        sh "docker build -t accountownerapp:test-B${BUILD_NUMBER} -f Dockerfile.Integration ."
  
    stage 'Integration Test'
        sh "docker-compose -f docker-compose.integration.j.yml up --force-recreate --abort-on-container-exit"
        sh "docker-compose -f docker-compose.integration.j.yml down -v"
}
