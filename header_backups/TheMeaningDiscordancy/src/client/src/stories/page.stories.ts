// Copyright © 2025 Steven Peterson
// All rights reserved.  
// 
// No part of this code may be copied, modified, distributed, or used  
// without explicit written permission from the author.
// 
// For licensing inquiries or collaboration opportunities:
// 
// GitHub: https://github.com/peterss7  
// LinkedIn: https://www.linkedin.com/in/steven-peterson7405926/

import type { Meta, StoryObj } from '@storybook/angular';

import { PageComponent } from './page.component';

const meta: Meta<PageComponent> = {
  title: 'Example/Page',
  component: PageComponent,
  parameters: {
    // More on how to position stories at: https://storybook.js.org/docs/configure/story-layout
    layout: 'fullscreen',
  },
};

export default meta;
type Story = StoryObj<PageComponent>;

export const LoggedOut: Story = {};

// More on component testing: https://storybook.js.org/docs/writing-tests/component-testing
export const LoggedIn: Story = {
  // play: async ({ canvasElement }) => {
  //   const canvas = within(canvasElement);
  //   const loginButton = canvas.getByRole('button', { name: /Log in/i });
  //   await expect(loginButton).toBeInTheDocument();
  //   await userEvent.click(loginButton);
  //   await expect(loginButton).not.toBeInTheDocument();

  //   const logoutButton = canvas.getByRole('button', { name: /Log out/i });
  //   await expect(logoutButton).toBeInTheDocument();
  // },
};
