import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductCreateReactive } from './product-create-reactive';

describe('ProductCreateReactive', () => {
  let component: ProductCreateReactive;
  let fixture: ComponentFixture<ProductCreateReactive>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProductCreateReactive],
    }).compileComponents();

    fixture = TestBed.createComponent(ProductCreateReactive);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
