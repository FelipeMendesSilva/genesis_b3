# angular-app/Dockerfile
FROM node:20 AS builder

WORKDIR /app
COPY . .
RUN npm install
RUN npm run build 

FROM nginx:stable-alpine
COPY --from=builder /app/dist/CdbFront/browser /usr/share/nginx/html
