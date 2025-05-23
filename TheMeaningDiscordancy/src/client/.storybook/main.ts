import type { StorybookConfig } from '@storybook/angular';

const config: StorybookConfig = {
  "stories": [
    "../src/**/*.stories.ts",
    "../src/**/*.stories.mdx"
  ],
  "addons": [
    "@storybook/addon-docs",
    "@storybook/addon-essentials",
  ],
  "framework": {
    "name": "@storybook/angular",
    "options": {}
  }
};
export default config;