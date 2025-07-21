import { Component, Injectable } from '@angular/core';
import { CdbResponse, PostService } from '../services/post.service';

@Component({
  selector: 'app-calculator',
  standalone: false,
  templateUrl: './calculator.html',
  styleUrl: './calculator.scss'
})
@Injectable()
export class Calculator {
  cdbValue: number = 0;
  cdbMonths: number = 0;
  posts: CdbResponse | null = null;

  constructor(private postService: PostService) { }

  calculate() {
    this.postService.cdbPost(this.cdbValue, this.cdbMonths)
      .subscribe(
        {
          next: (res: CdbResponse) => { this.posts = res; },
          error: (err) => {
            console.error('Erro na requisição:', err);
            this.posts = null; // limpa resultado anterior, se quiser
            alert('Ocorreu um erro ao calcular o CDB. Tente novamente mais tarde.');
          }
        });
  }

  zerarResultado() {
    this.posts = null;
  }

  valido(): boolean {
    return this.cdbValue > 0 && this.cdbMonths > 0;
  }
}
