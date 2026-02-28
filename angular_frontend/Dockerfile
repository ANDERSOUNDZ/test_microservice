FROM node:22-alpine AS build
WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . . 
RUN npm run build -- --configuration production

FROM nginx:alpine
# Verifica que el nombre después de /dist/ coincida con tu proyecto
COPY --from=build /app/dist/angular_frontend/browser /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]