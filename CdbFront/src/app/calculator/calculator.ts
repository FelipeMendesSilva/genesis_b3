import { Component, Injectable } from '@angular/core';
import { CdbData, CdbResponse, PostService } from '../services/post.service';

@Component({
  selector: 'app-calculator',
  standalone: false,
  templateUrl: './calculator.html',
  styleUrl: './calculator.scss'
})
@Injectable()
export class Calculator {
  cdbValue: number = 100.00;
  cdbMonths: number = 1;
  errorCdbValueCss: boolean = false;
  errorCdbMonthsCss: boolean = false;
  posts: CdbData | null = null;

  constructor(private postService: PostService) { }

  calculate() {
    this.postService.cdbPost(this.cdbValue, this.cdbMonths)
      .subscribe(
        {
          next: (res: CdbResponse<CdbData>) => {
            this.posts = res.data;
          },
          error: (err) => {
            console.error('Erro na requisição:', err);
            this.posts = null; // limpa resultado anterior, se quiser
            alert('Ocorreu um erro ao calcular o CDB. Tente novamente mais tarde.');
          }
        });
  }

  cleanResult() {
    this.posts = null;
  }

  onlyPositive(event: KeyboardEvent, isInt: boolean): void {
    if (event.key === '-'
      || event.key === 'Minus'
      || (isInt && event.key === '.')
      || (isInt && event.key === ',')) {
      event.preventDefault();
    }
    this.cleanResult();
  }

  valid(): boolean {
    var isValid = true;
    if(this.cdbValue >= 0.01 && this.cdbValue.toString().match(/^\d*((\.|\,)\d{0,2})?$/))
      this.errorCdbValueCss = false;
    else{
      this.errorCdbValueCss = true;
      isValid = false;}

    if(this.cdbMonths >= 1 && Number.isInteger(this.cdbMonths))
      this.errorCdbMonthsCss = false;
    else{
      this.errorCdbMonthsCss = true;
      isValid = false;}

    return isValid;
  }
}
