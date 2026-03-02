import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  show(message: string, success: boolean) {
    console.log(`${success ? 'OK' : 'Error'} ${message}`);
    alert(message);
  }
}
