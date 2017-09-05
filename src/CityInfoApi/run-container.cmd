docker rm cityinfoapi
docker run -d -p 5000:5000 --name cityinfoapi -t cityinfoapi:latest

pause