import { CommonModule } from '@angular/common';
import { inject, Component, OnInit } from '@angular/core';
import { UsersService } from '../../services/users.service';
import User from '../../models/user.entity';
import { MatTableModule } from '@angular/material/table';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, MatTableModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  title = 'Пользователи';
  users: MatTableDataSource<User> = new MatTableDataSource<User>([]);
  displayedColumns: string[] = ['id', 'name'];

  // инжектим сервис
  usersService = inject(UsersService);

  ngOnInit() {
    this.usersService.getAll().subscribe({
      next: v => {
        console.log('API response:', v); // для проверки данных из API
        this.users.data = v; // обновляем MatTableDataSource
      },
      error: e => console.error(e)
    });
  }
}