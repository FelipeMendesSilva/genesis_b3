import { TestBed } from '@angular/core/testing';
import { provideHttpClientTesting, HttpTestingController } from '@angular/common/http/testing';
import { provideHttpClient } from '@angular/common/http';
import { PostService, CdbResponse, CdbData } from './post.service';
import { CDB_API } from '../app.api';

fdescribe('PostService', () => {
  let service: PostService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        PostService,
        provideHttpClient(),
        provideHttpClientTesting()]
    });

    service = TestBed.inject(PostService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify(); // Verifica se não há requisições pendentes
  });

  it('deve realizar POST e retornar dados esperados', () => {
    const mockResponse: CdbResponse<CdbData> = {
      statusCode: 200,
      data: {
        grossAmount: 1059.76,
        netAmount: 1046.31
      },
      errorMessage: null
    };

    service.cdbPost(1000, 6).subscribe(response => {
      expect(response.statusCode).toBe(200);
      expect(response.data?.grossAmount).toBe(1059.76);
      expect(response.data?.netAmount).toBe(1046.31);
      expect(response.errorMessage).toBeNull();
    });

    const req = httpMock.expectOne(`${CDB_API}/api/cdb/yield`);
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual({ value: 1000, months: 6 });

    req.flush(mockResponse); // Responde com o mock
  });

  it('deve tratar erro de resposta HTTP', () => {
    service.cdbPost(1000, 3).subscribe({
      next: () => fail('Esperado erro, mas resposta foi sucesso'),
      error: (error) => {
        expect(error.message).toContain('Erro 500');
      }
    });

    const req = httpMock.expectOne(`${CDB_API}/api/cdb/yield`);
    req.flush('Erro interno no servidor', { status: 500, statusText: 'Internal Server Error' });
  });
});