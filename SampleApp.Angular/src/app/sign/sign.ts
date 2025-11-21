import { Component, inject } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { S } from '@angular/cdk/keycodes';
import { SignService } from '../../services/sign.service';
import { MatFormField, MatFormFieldModule, MatLabel } from "@angular/material/form-field";
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-sign',
  imports: [FormsModule, MatInputModule, MatFormFieldModule, MatIconModule, MatButtonModule],
  templateUrl: './sign.html',
  styleUrl: './sign.scss',
})
export class Sign {
    authService = inject(SignService)
    model:any = {}
    sign()
    {
      this.authService.register(this.model).subscribe({next: r => console.log(r),error: e => console.log(e.error)})
    }
}
