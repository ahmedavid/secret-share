import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Secret } from 'src/app/_models/interfaces';
import { SecretService } from 'src/app/_services/secret.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-secret-create',
  templateUrl: './secret-create.component.html',
  styleUrls: ['./secret-create.component.scss'],
})
export class SecretCreateComponent implements OnInit {
  isAccessAttemptsSet = false;
  model: {
    body: string;
    availableFrom: string;
    expiresAt: string;
    accessAttemptsLeft: number;
  };

  constructor(private secretService: SecretService, private router: Router) {
    const now = new Date();
    const later = new Date();
    later.setDate(now.getDate() + 7);

    console.log(now.toISOString())
    this.model = {
      body: 'TEST',
      availableFrom: now.toISOString(),
      expiresAt: later.toISOString(),
      accessAttemptsLeft: 3,
    };

    console.log(environment)
  }

  ngOnInit(): void {}

  onSubmit() {
    // console.log(this.model)
    if (!this.isAccessAttemptsSet) {
      this.model.accessAttemptsLeft = -1;
    }
    this.secretService.createSecret(this.model).subscribe({
      next: (secret) => {
        console.log(secret);
        this.router.navigateByUrl('/secret/created/' + secret.id);
      },
    });
  }

  accessAttemptSwitch(ev: any) {
    console.log(ev);
    this.isAccessAttemptsSet = ev.target.value;
  }

  testChange(ev: any) {
    console.log(ev);
  }

  loadSecrets() {
    // this.secretService.getSecrets().subscribe({
    //   next: secrets => this.secrets = secrets
    // })
  }

  getLink(secret: Secret) {
    return `http://localhost:4200/secret/${secret.id}`;
  }
}
