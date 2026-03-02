import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../../core/services/user.service';

@Component({
  selector: 'app-users.component',
  imports: [CommonModule, FormsModule],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css',
})
export class UsersComponent implements OnInit {
  userService = inject(UserService);

  form = {
    username: '',
    nombreCompleto: '',
  };

  ngOnInit() {
    this.userService.listar();
  }

  guardar() {
    this.userService.registrar(this.form).subscribe({
      next: () => {
        this.form = { username: '', nombreCompleto: '' };
      },
    });
  }
}
