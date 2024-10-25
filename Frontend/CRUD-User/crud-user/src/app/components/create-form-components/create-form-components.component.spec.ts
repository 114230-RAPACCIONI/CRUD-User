import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateFormComponentsComponent } from './create-form-components.component';

describe('CreateFormComponentsComponent', () => {
  let component: CreateFormComponentsComponent;
  let fixture: ComponentFixture<CreateFormComponentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateFormComponentsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateFormComponentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
