import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { KredilerService } from './services/krediler.service';
import { KredilerDto } from './models/krediler.dto';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  constructor(private _kredilerService: KredilerService) {

  }
  krediler: KredilerDto[] = []
  ngOnInit(): void {
    this._kredilerService.getKrediler().subscribe({
      next: (datas :KredilerDto[]) => {
        this.krediler = datas;
        console.log(this.krediler)
      }
    })
  }
  title = 'angular';
}
