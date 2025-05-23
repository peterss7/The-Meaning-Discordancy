import type { Preview } from '@storybook/angular';

const preview: Preview = {
    parameters: {
        backgrounds: {
            default: 'light',
            values: [
                { name: 'light', value: '#ffffff' },
                { name: 'dark', value: '#1e1e1e' },
            ],
        },
    },
};

export default preview;
