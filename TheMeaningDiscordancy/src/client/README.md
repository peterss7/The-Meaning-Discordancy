# Client

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 15.0.4.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.

## 📦 Storybook Setup (for Angular 15)
# bash
npm install --save-dev \
@storybook/angular@7.6.16 \
@storybook/addon-essentials@7.6.16 \
@storybook/addon-interactions@7.6.16 \
@storybook/addon-docs@7.6.16 \
@storybook/blocks@7.6.16 \
@storybook/test@7.6.16 \
storybook@7.6.16

chmod +x scripts/setup-storybook.sh
./scripts/setup-storybook.sh
