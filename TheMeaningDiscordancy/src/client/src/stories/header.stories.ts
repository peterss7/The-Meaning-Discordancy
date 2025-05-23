import type { Meta, StoryObj } from '@storybook/angular';

import { HeaderComponent } from './header.component';

const meta: Meta<HeaderComponent> = {
  title: 'Example/Header',
  component: HeaderComponent,
  tags: ['autodocs'],
};

export default meta;

type Story = StoryObj<HeaderComponent>;

export const LoggedIn: Story = {
  args: {
    user: {
      name: 'Jane Doe',
    },
  },
};

export const LoggedOut: Story = {};
