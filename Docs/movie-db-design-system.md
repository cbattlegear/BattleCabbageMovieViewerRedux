# Movie Database Design System

> A comprehensive design system for building a modern, cinematic movie database application. This document provides all design tokens, component guidelines, and implementation patterns needed for consistent UI development.

---

## Table of Contents

1. [Design Philosophy](#design-philosophy)
2. [Color System](#color-system)
3. [Typography](#typography)
4. [Spacing & Layout](#spacing--layout)
5. [Border Radius](#border-radius)
6. [Shadows & Elevation](#shadows--elevation)
7. [Animations & Transitions](#animations--transitions)
8. [Component Specifications](#component-specifications)
9. [Iconography](#iconography)
10. [Accessibility Guidelines](#accessibility-guidelines)
11. [Implementation Examples](#implementation-examples)

---

## Design Philosophy

### Core Principles

1. **Cinema-First**: Dark mode is the primary experience, mimicking the theater environment
2. **Content is Hero**: UI should recede; movie posters, backdrops, and imagery should dominate
3. **Warm & Inviting**: Gold accents evoke awards prestige; red accents evoke theater energy
4. **Scannable**: Users browse large catalogs—optimize for quick visual parsing
5. **Responsive**: Seamless experience from mobile to large displays

### Visual Language

- **Mood**: Premium, immersive, editorial
- **Inspiration**: Film festivals, theater marquees, streaming platforms, entertainment magazines
- **Avoid**: Harsh whites, overly saturated colors competing with poster art, cluttered layouts

---

## Color System

### Dark Mode (Primary)

```css
:root[data-theme="dark"] {
  /* Backgrounds */
  --color-bg-primary: #0D0D0F;        /* Main app background */
  --color-bg-secondary: #1A1A1F;      /* Cards, modals, sidebars */
  --color-bg-tertiary: #252530;       /* Elevated surfaces, hover states */
  --color-bg-elevated: #2D2D35;       /* Dropdowns, tooltips, popovers */
  
  /* Text */
  --color-text-primary: #F5F5F7;      /* Headings, important text */
  --color-text-secondary: #9CA3AF;    /* Body text, descriptions */
  --color-text-tertiary: #6B7280;     /* Captions, metadata, timestamps */
  --color-text-disabled: #4B5563;     /* Disabled states */
  
  /* Brand / Accent */
  --color-accent-gold: #F5C518;       /* Primary accent - ratings, stars, featured */
  --color-accent-gold-hover: #FACC15; /* Gold hover state */
  --color-accent-gold-muted: #CA8A04; /* Gold on light backgrounds within dark mode */
  
  --color-accent-red: #E50914;        /* Secondary accent - CTAs, watchlist, trailers */
  --color-accent-red-hover: #F71B26;  /* Red hover state */
  --color-accent-red-muted: #B91C1C;  /* Subtle red for borders/indicators */
  
  /* Semantic Colors */
  --color-success: #10B981;           /* High ratings (70%+), positive states */
  --color-success-muted: #059669;     /* Success backgrounds */
  --color-warning: #F59E0B;           /* Medium ratings (50-69%), caution */
  --color-warning-muted: #D97706;     /* Warning backgrounds */
  --color-error: #EF4444;             /* Low ratings (<50%), errors */
  --color-error-muted: #DC2626;       /* Error backgrounds */
  --color-info: #3B82F6;              /* Informational, links */
  --color-info-muted: #2563EB;        /* Info backgrounds */
  
  /* Borders & Dividers */
  --color-border-primary: #2D2D35;    /* Card borders, dividers */
  --color-border-secondary: #3F3F46;  /* Input borders, subtle separators */
  --color-border-focus: #F5C518;      /* Focus rings */
  
  /* Overlays */
  --color-overlay-light: rgba(255, 255, 255, 0.05);  /* Subtle hover overlays */
  --color-overlay-medium: rgba(255, 255, 255, 0.10); /* Active states */
  --color-overlay-dark: rgba(0, 0, 0, 0.60);         /* Modal backdrops */
  --color-overlay-gradient: linear-gradient(to top, rgba(13, 13, 15, 0.95) 0%, transparent 100%);
}
```

### Light Mode

```css
:root[data-theme="light"] {
  /* Backgrounds */
  --color-bg-primary: #FAFAFA;        /* Main app background */
  --color-bg-secondary: #FFFFFF;      /* Cards, modals, sidebars */
  --color-bg-tertiary: #F3F4F6;       /* Elevated surfaces, hover states */
  --color-bg-elevated: #FFFFFF;       /* Dropdowns, tooltips, popovers */
  
  /* Text */
  --color-text-primary: #111827;      /* Headings, important text */
  --color-text-secondary: #4B5563;    /* Body text, descriptions */
  --color-text-tertiary: #6B7280;     /* Captions, metadata, timestamps */
  --color-text-disabled: #9CA3AF;     /* Disabled states */
  
  /* Brand / Accent */
  --color-accent-gold: #CA8A04;       /* Primary accent - darkened for contrast */
  --color-accent-gold-hover: #A16207; /* Gold hover state */
  --color-accent-gold-muted: #FEF3C7; /* Gold backgrounds */
  
  --color-accent-red: #DC2626;        /* Secondary accent - CTAs, watchlist */
  --color-accent-red-hover: #B91C1C;  /* Red hover state */
  --color-accent-red-muted: #FEE2E2;  /* Subtle red backgrounds */
  
  /* Semantic Colors */
  --color-success: #059669;           /* High ratings, positive states */
  --color-success-muted: #D1FAE5;     /* Success backgrounds */
  --color-warning: #D97706;           /* Medium ratings, caution */
  --color-warning-muted: #FEF3C7;     /* Warning backgrounds */
  --color-error: #DC2626;             /* Low ratings, errors */
  --color-error-muted: #FEE2E2;       /* Error backgrounds */
  --color-info: #2563EB;              /* Informational, links */
  --color-info-muted: #DBEAFE;        /* Info backgrounds */
  
  /* Borders & Dividers */
  --color-border-primary: #E5E7EB;    /* Card borders, dividers */
  --color-border-secondary: #D1D5DB;  /* Input borders */
  --color-border-focus: #CA8A04;      /* Focus rings */
  
  /* Overlays */
  --color-overlay-light: rgba(0, 0, 0, 0.03);   /* Subtle hover overlays */
  --color-overlay-medium: rgba(0, 0, 0, 0.06);  /* Active states */
  --color-overlay-dark: rgba(0, 0, 0, 0.50);    /* Modal backdrops */
  --color-overlay-gradient: linear-gradient(to top, rgba(250, 250, 250, 0.95) 0%, transparent 100%);
}
```

### Rating Color Scale

Use these colors for displaying movie/show ratings:

| Score Range | Color Variable | Dark Mode | Light Mode | Usage |
|-------------|----------------|-----------|------------|-------|
| 90-100% | `--rating-excellent` | `#22C55E` | `#16A34A` | Exceptional content |
| 70-89% | `--rating-good` | `#10B981` | `#059669` | Well-received |
| 50-69% | `--rating-mixed` | `#F59E0B` | `#D97706` | Mixed reception |
| 25-49% | `--rating-poor` | `#F97316` | `#EA580C` | Below average |
| 0-24% | `--rating-bad` | `#EF4444` | `#DC2626` | Poorly received |
| No Rating | `--rating-none` | `#6B7280` | `#9CA3AF` | Unrated/TBD |

---

## Typography

### Font Stack

```css
:root {
  /* Primary font for UI, headings, and body */
  --font-sans: 'Inter', -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif;
  
  /* Display font for hero sections (optional, use sparingly) */
  --font-display: 'Inter', var(--font-sans);
  
  /* Monospace for technical info (runtime, codes) */
  --font-mono: 'JetBrains Mono', 'Fira Code', 'Consolas', monospace;
}
```

### Type Scale

```css
:root {
  /* Font Sizes */
  --text-xs: 0.75rem;      /* 12px - Timestamps, badges */
  --text-sm: 0.875rem;     /* 14px - Captions, metadata */
  --text-base: 1rem;       /* 16px - Body text */
  --text-lg: 1.125rem;     /* 18px - Lead paragraphs */
  --text-xl: 1.25rem;      /* 20px - Card titles */
  --text-2xl: 1.5rem;      /* 24px - Section headers */
  --text-3xl: 1.875rem;    /* 30px - Page titles */
  --text-4xl: 2.25rem;     /* 36px - Hero titles */
  --text-5xl: 3rem;        /* 48px - Feature displays */
  --text-6xl: 3.75rem;     /* 60px - Large hero text */
  
  /* Line Heights */
  --leading-none: 1;
  --leading-tight: 1.25;
  --leading-snug: 1.375;
  --leading-normal: 1.5;
  --leading-relaxed: 1.625;
  --leading-loose: 2;
  
  /* Font Weights */
  --font-normal: 400;
  --font-medium: 500;
  --font-semibold: 600;
  --font-bold: 700;
  --font-extrabold: 800;
  
  /* Letter Spacing */
  --tracking-tighter: -0.05em;
  --tracking-tight: -0.025em;
  --tracking-normal: 0;
  --tracking-wide: 0.025em;
  --tracking-wider: 0.05em;
  --tracking-widest: 0.1em;
}
```

### Typography Patterns

| Element | Size | Weight | Line Height | Letter Spacing | Color |
|---------|------|--------|-------------|----------------|-------|
| Hero Title | `--text-5xl` / `--text-6xl` | `--font-bold` | `--leading-tight` | `--tracking-tight` | `--color-text-primary` |
| Page Title | `--text-3xl` / `--text-4xl` | `--font-bold` | `--leading-tight` | `--tracking-tight` | `--color-text-primary` |
| Section Header | `--text-xl` / `--text-2xl` | `--font-semibold` | `--leading-snug` | `--tracking-normal` | `--color-text-primary` |
| Card Title | `--text-lg` / `--text-xl` | `--font-semibold` | `--leading-snug` | `--tracking-normal` | `--color-text-primary` |
| Body Text | `--text-base` | `--font-normal` | `--leading-relaxed` | `--tracking-normal` | `--color-text-secondary` |
| Caption | `--text-sm` | `--font-normal` | `--leading-normal` | `--tracking-normal` | `--color-text-tertiary` |
| Overline/Label | `--text-xs` | `--font-semibold` | `--leading-normal` | `--tracking-wider` | `--color-text-tertiary` |
| Badge | `--text-xs` | `--font-medium` | `--leading-none` | `--tracking-wide` | Contextual |

---

## Spacing & Layout

### Spacing Scale

```css
:root {
  --space-0: 0;
  --space-px: 1px;
  --space-0.5: 0.125rem;   /* 2px */
  --space-1: 0.25rem;      /* 4px */
  --space-1.5: 0.375rem;   /* 6px */
  --space-2: 0.5rem;       /* 8px */
  --space-2.5: 0.625rem;   /* 10px */
  --space-3: 0.75rem;      /* 12px */
  --space-3.5: 0.875rem;   /* 14px */
  --space-4: 1rem;         /* 16px */
  --space-5: 1.25rem;      /* 20px */
  --space-6: 1.5rem;       /* 24px */
  --space-7: 1.75rem;      /* 28px */
  --space-8: 2rem;         /* 32px */
  --space-9: 2.25rem;      /* 36px */
  --space-10: 2.5rem;      /* 40px */
  --space-12: 3rem;        /* 48px */
  --space-14: 3.5rem;      /* 56px */
  --space-16: 4rem;        /* 64px */
  --space-20: 5rem;        /* 80px */
  --space-24: 6rem;        /* 96px */
  --space-32: 8rem;        /* 128px */
}
```

### Layout Containers

```css
:root {
  --container-sm: 640px;
  --container-md: 768px;
  --container-lg: 1024px;
  --container-xl: 1280px;
  --container-2xl: 1536px;
  --container-max: 1800px;   /* Maximum content width */
  
  /* Page padding */
  --page-padding-mobile: var(--space-4);    /* 16px */
  --page-padding-tablet: var(--space-6);    /* 24px */
  --page-padding-desktop: var(--space-8);   /* 32px */
}
```

### Grid System

```css
:root {
  /* Grid gaps */
  --grid-gap-sm: var(--space-3);    /* 12px - Tight grids */
  --grid-gap-md: var(--space-4);    /* 16px - Standard grids */
  --grid-gap-lg: var(--space-6);    /* 24px - Spacious grids */
  --grid-gap-xl: var(--space-8);    /* 32px - Section spacing */
}
```

### Poster Aspect Ratios

```css
:root {
  /* Standard movie poster */
  --aspect-poster: 2 / 3;           /* 0.667 - Standard movie poster */
  --aspect-backdrop: 16 / 9;        /* 1.778 - Backdrop images */
  --aspect-square: 1 / 1;           /* 1.0 - Profile images, thumbnails */
  --aspect-wide: 21 / 9;            /* 2.333 - Ultra-wide hero banners */
}
```

---

## Border Radius

```css
:root {
  --radius-none: 0;
  --radius-sm: 0.25rem;     /* 4px - Badges, small buttons */
  --radius-md: 0.375rem;    /* 6px - Inputs, small cards */
  --radius-lg: 0.5rem;      /* 8px - Standard cards, buttons */
  --radius-xl: 0.75rem;     /* 12px - Large cards, modals */
  --radius-2xl: 1rem;       /* 16px - Hero cards, featured content */
  --radius-3xl: 1.5rem;     /* 24px - Large containers */
  --radius-full: 9999px;    /* Pills, avatars, circular elements */
}
```

---

## Shadows & Elevation

### Dark Mode Shadows

```css
:root[data-theme="dark"] {
  --shadow-sm: 0 1px 2px 0 rgba(0, 0, 0, 0.3);
  --shadow-md: 0 4px 6px -1px rgba(0, 0, 0, 0.4), 0 2px 4px -2px rgba(0, 0, 0, 0.3);
  --shadow-lg: 0 10px 15px -3px rgba(0, 0, 0, 0.5), 0 4px 6px -4px rgba(0, 0, 0, 0.4);
  --shadow-xl: 0 20px 25px -5px rgba(0, 0, 0, 0.5), 0 8px 10px -6px rgba(0, 0, 0, 0.4);
  --shadow-2xl: 0 25px 50px -12px rgba(0, 0, 0, 0.6);
  
  /* Glow effects for accent elements */
  --shadow-glow-gold: 0 0 20px rgba(245, 197, 24, 0.3);
  --shadow-glow-red: 0 0 20px rgba(229, 9, 20, 0.3);
  
  /* Card hover shadow */
  --shadow-card-hover: 0 20px 40px -15px rgba(0, 0, 0, 0.5);
}
```

### Light Mode Shadows

```css
:root[data-theme="light"] {
  --shadow-sm: 0 1px 2px 0 rgba(0, 0, 0, 0.05);
  --shadow-md: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -2px rgba(0, 0, 0, 0.1);
  --shadow-lg: 0 10px 15px -3px rgba(0, 0, 0, 0.1), 0 4px 6px -4px rgba(0, 0, 0, 0.1);
  --shadow-xl: 0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 8px 10px -6px rgba(0, 0, 0, 0.1);
  --shadow-2xl: 0 25px 50px -12px rgba(0, 0, 0, 0.25);
  
  /* Subtle glow for light mode */
  --shadow-glow-gold: 0 0 20px rgba(202, 138, 4, 0.2);
  --shadow-glow-red: 0 0 20px rgba(220, 38, 38, 0.2);
  
  /* Card hover shadow */
  --shadow-card-hover: 0 20px 40px -15px rgba(0, 0, 0, 0.15);
}
```

### Elevation Levels

| Level | Usage | Shadow | Background Adjustment |
|-------|-------|--------|-----------------------|
| 0 | Base surface | None | `--color-bg-primary` |
| 1 | Cards, tiles | `--shadow-sm` | `--color-bg-secondary` |
| 2 | Dropdowns, popovers | `--shadow-md` | `--color-bg-tertiary` |
| 3 | Modals, dialogs | `--shadow-lg` | `--color-bg-elevated` |
| 4 | Notifications, toasts | `--shadow-xl` | `--color-bg-elevated` |

---

## Animations & Transitions

### Duration Scale

```css
:root {
  --duration-instant: 0ms;
  --duration-fast: 100ms;
  --duration-normal: 200ms;
  --duration-slow: 300ms;
  --duration-slower: 500ms;
  --duration-slowest: 700ms;
}
```

### Easing Functions

```css
:root {
  --ease-linear: linear;
  --ease-in: cubic-bezier(0.4, 0, 1, 1);
  --ease-out: cubic-bezier(0, 0, 0.2, 1);
  --ease-in-out: cubic-bezier(0.4, 0, 0.2, 1);
  --ease-bounce: cubic-bezier(0.68, -0.55, 0.265, 1.55);
  --ease-smooth: cubic-bezier(0.25, 0.1, 0.25, 1);
}
```

### Common Transitions

```css
:root {
  /* Pre-composed transitions */
  --transition-colors: color var(--duration-normal) var(--ease-in-out),
                       background-color var(--duration-normal) var(--ease-in-out),
                       border-color var(--duration-normal) var(--ease-in-out);
  --transition-opacity: opacity var(--duration-normal) var(--ease-in-out);
  --transition-transform: transform var(--duration-normal) var(--ease-out);
  --transition-shadow: box-shadow var(--duration-normal) var(--ease-in-out);
  --transition-all: all var(--duration-normal) var(--ease-in-out);
}
```

### Animation Keyframes

```css
@keyframes fadeIn {
  from { opacity: 0; }
  to { opacity: 1; }
}

@keyframes fadeInUp {
  from {
    opacity: 0;
    transform: translateY(10px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

@keyframes fadeInScale {
  from {
    opacity: 0;
    transform: scale(0.95);
  }
  to {
    opacity: 1;
    transform: scale(1);
  }
}

@keyframes slideInRight {
  from {
    opacity: 0;
    transform: translateX(20px);
  }
  to {
    opacity: 1;
    transform: translateX(0);
  }
}

@keyframes pulse {
  0%, 100% { opacity: 1; }
  50% { opacity: 0.5; }
}

@keyframes shimmer {
  0% { background-position: -200% 0; }
  100% { background-position: 200% 0; }
}
```

### Animation Classes

```css
.animate-fade-in { animation: fadeIn var(--duration-normal) var(--ease-out); }
.animate-fade-in-up { animation: fadeInUp var(--duration-slow) var(--ease-out); }
.animate-fade-in-scale { animation: fadeInScale var(--duration-slow) var(--ease-out); }
.animate-slide-in-right { animation: slideInRight var(--duration-slow) var(--ease-out); }
.animate-pulse { animation: pulse 2s var(--ease-in-out) infinite; }
.animate-shimmer {
  background: linear-gradient(90deg, transparent 0%, var(--color-overlay-light) 50%, transparent 100%);
  background-size: 200% 100%;
  animation: shimmer 1.5s infinite;
}
```

---

## Component Specifications

### Movie Poster Card

```
┌─────────────────────────────┐
│                             │
│         [POSTER]            │  Aspect ratio: 2:3
│         IMAGE               │  Border radius: --radius-lg
│                             │  Hover: scale(1.03), --shadow-card-hover
│                             │
├─────────────────────────────┤
│ ★ 8.5                       │  Rating badge (absolute positioned)
├─────────────────────────────┤
│ Movie Title                 │  --text-base, --font-semibold, truncate 2 lines
│ 2024 • Action               │  --text-sm, --color-text-tertiary
└─────────────────────────────┘
```

**Specifications:**
- Container: `--radius-lg`, overflow hidden
- Poster: `aspect-ratio: var(--aspect-poster)`, object-fit: cover
- Rating badge: Position absolute, top-right, `--space-2` offset
- Title: Max 2 lines with ellipsis
- Hover: Transform scale(1.03), add `--shadow-card-hover`, 200ms transition
- Skeleton: Use `--color-bg-tertiary` with shimmer animation

### Rating Badge

```
┌───────────┐
│  ★ 8.5    │
└───────────┘
```

**Specifications:**
- Background: Semi-transparent black (`rgba(0,0,0,0.75)`) or semantic color based on score
- Padding: `--space-1` vertical, `--space-2` horizontal
- Border radius: `--radius-md`
- Font: `--text-sm`, `--font-semibold`
- Star icon: `--color-accent-gold`, sized to match text

### Button Variants

#### Primary Button (Gold)
```css
.btn-primary {
  background: var(--color-accent-gold);
  color: #000000;
  padding: var(--space-2.5) var(--space-5);
  border-radius: var(--radius-lg);
  font-weight: var(--font-semibold);
  font-size: var(--text-sm);
  transition: var(--transition-all);
}
.btn-primary:hover {
  background: var(--color-accent-gold-hover);
  transform: translateY(-1px);
  box-shadow: var(--shadow-glow-gold);
}
```

#### Secondary Button (Red/CTA)
```css
.btn-secondary {
  background: var(--color-accent-red);
  color: #FFFFFF;
  padding: var(--space-2.5) var(--space-5);
  border-radius: var(--radius-lg);
  font-weight: var(--font-semibold);
  font-size: var(--text-sm);
  transition: var(--transition-all);
}
.btn-secondary:hover {
  background: var(--color-accent-red-hover);
  transform: translateY(-1px);
  box-shadow: var(--shadow-glow-red);
}
```

#### Ghost Button
```css
.btn-ghost {
  background: transparent;
  color: var(--color-text-primary);
  padding: var(--space-2.5) var(--space-5);
  border: 1px solid var(--color-border-primary);
  border-radius: var(--radius-lg);
  font-weight: var(--font-medium);
  font-size: var(--text-sm);
  transition: var(--transition-all);
}
.btn-ghost:hover {
  background: var(--color-overlay-light);
  border-color: var(--color-border-secondary);
}
```

#### Icon Button
```css
.btn-icon {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 40px;
  height: 40px;
  background: var(--color-bg-tertiary);
  border-radius: var(--radius-full);
  color: var(--color-text-secondary);
  transition: var(--transition-all);
}
.btn-icon:hover {
  background: var(--color-bg-elevated);
  color: var(--color-text-primary);
}
```

### Input Field

```css
.input {
  width: 100%;
  padding: var(--space-3) var(--space-4);
  background: var(--color-bg-tertiary);
  border: 1px solid var(--color-border-primary);
  border-radius: var(--radius-lg);
  color: var(--color-text-primary);
  font-size: var(--text-base);
  transition: var(--transition-all);
}
.input::placeholder {
  color: var(--color-text-tertiary);
}
.input:focus {
  outline: none;
  border-color: var(--color-border-focus);
  box-shadow: 0 0 0 3px rgba(245, 197, 24, 0.15);
}
```

### Search Bar

```
┌─────────────────────────────────────────────┐
│ 🔍  Search movies, TV shows, people...      │
└─────────────────────────────────────────────┘
```

**Specifications:**
- Full width or max-width: 600px centered
- Height: 48px - 56px
- Background: `--color-bg-tertiary`
- Border: 1px solid `--color-border-primary`
- Border radius: `--radius-full` for pill shape or `--radius-xl`
- Icon: `--color-text-tertiary`, 20px
- Placeholder: `--color-text-tertiary`
- Focus: Border `--color-accent-gold`, subtle glow

### Navigation Bar

**Desktop:**
- Height: 64px
- Background: `--color-bg-primary` with backdrop blur
- Border bottom: 1px solid `--color-border-primary`
- Logo: Left aligned
- Navigation links: Center
- Search + User: Right aligned

**Mobile:**
- Height: 56px
- Hamburger menu
- Bottom navigation for primary actions

### Movie Detail Hero

```
┌─────────────────────────────────────────────────────────────┐
│                                                             │
│                     [BACKDROP IMAGE]                        │
│                     with gradient overlay                   │
│                                                             │
├─────────────────────────────────────────────────────────────┤
│ ┌──────┐                                                    │
│ │POSTER│  MOVIE TITLE (YEAR)                               │
│ │      │  ★ 8.5 • 2h 15m • PG-13                           │
│ │      │  Action, Adventure, Sci-Fi                        │
│ │      │                                                    │
│ │      │  [▶ Watch Trailer]  [+ Watchlist]  [♡]            │
│ └──────┘                                                    │
│                                                             │
│ Overview                                                    │
│ Lorem ipsum dolor sit amet, consectetur adipiscing elit...  │
└─────────────────────────────────────────────────────────────┘
```

**Specifications:**
- Backdrop: Full width, 50-60vh height, `--aspect-backdrop`
- Gradient overlay: `--color-overlay-gradient`
- Poster: 300px width on desktop, `--aspect-poster`, `--shadow-2xl`
- Title: `--text-4xl` / `--text-5xl`, `--font-bold`
- Metadata: `--text-base`, `--color-text-secondary`

### Tabs

```css
.tabs {
  display: flex;
  gap: var(--space-1);
  border-bottom: 1px solid var(--color-border-primary);
}
.tab {
  padding: var(--space-3) var(--space-4);
  color: var(--color-text-secondary);
  font-weight: var(--font-medium);
  border-bottom: 2px solid transparent;
  transition: var(--transition-colors);
}
.tab:hover {
  color: var(--color-text-primary);
}
.tab.active {
  color: var(--color-accent-gold);
  border-bottom-color: var(--color-accent-gold);
}
```

### Skeleton Loading

```css
.skeleton {
  background: var(--color-bg-tertiary);
  border-radius: var(--radius-md);
  overflow: hidden;
  position: relative;
}
.skeleton::after {
  content: '';
  position: absolute;
  inset: 0;
  background: linear-gradient(
    90deg,
    transparent 0%,
    var(--color-overlay-light) 50%,
    transparent 100%
  );
  background-size: 200% 100%;
  animation: shimmer 1.5s infinite;
}
```

### Carousel/Slider

**Specifications:**
- Gap between items: `--space-4`
- Scroll snap: `snap-x snap-mandatory`
- Items: `snap-start`
- Navigation arrows: Positioned at edges, semi-transparent background
- Scroll indicators: Small dots below carousel
- Peek: Show partial next item to indicate scrollability

### Modal/Dialog

```css
.modal-backdrop {
  position: fixed;
  inset: 0;
  background: var(--color-overlay-dark);
  backdrop-filter: blur(4px);
  animation: fadeIn var(--duration-normal) var(--ease-out);
}
.modal {
  position: fixed;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background: var(--color-bg-secondary);
  border-radius: var(--radius-xl);
  box-shadow: var(--shadow-2xl);
  max-width: 90vw;
  max-height: 90vh;
  overflow: auto;
  animation: fadeInScale var(--duration-slow) var(--ease-out);
}
```

### Toast/Notification

```css
.toast {
  display: flex;
  align-items: center;
  gap: var(--space-3);
  padding: var(--space-4);
  background: var(--color-bg-elevated);
  border-radius: var(--radius-lg);
  box-shadow: var(--shadow-xl);
  animation: slideInRight var(--duration-slow) var(--ease-out);
}
```

---

## Iconography

### Icon Sizing

```css
:root {
  --icon-xs: 12px;
  --icon-sm: 16px;
  --icon-md: 20px;
  --icon-lg: 24px;
  --icon-xl: 32px;
  --icon-2xl: 48px;
}
```

### Recommended Icon Set

Use **Lucide Icons** or **Heroicons** for consistency. Key icons needed:

| Purpose | Icon Name | Usage |
|---------|-----------|-------|
| Search | `search` | Navigation, search bars |
| Play | `play`, `play-circle` | Trailers, videos |
| Bookmark | `bookmark`, `bookmark-plus` | Watchlist |
| Heart | `heart` | Favorites |
| Star | `star`, `star-half` | Ratings |
| User | `user`, `user-circle` | Profiles |
| Home | `home` | Navigation |
| Film | `film`, `clapperboard` | Movies section |
| TV | `tv`, `monitor` | TV shows section |
| Calendar | `calendar` | Release dates |
| Clock | `clock` | Runtime |
| Share | `share-2` | Sharing |
| External Link | `external-link` | External resources |
| Chevron | `chevron-right`, `chevron-down` | Navigation, expand |
| Close | `x` | Modals, dismiss |
| Menu | `menu` | Mobile navigation |
| Filter | `filter`, `sliders` | Filtering |
| Sort | `arrow-up-down` | Sorting |

---

## Accessibility Guidelines

### Color Contrast

All text must meet WCAG 2.1 AA standards:
- Normal text: 4.5:1 minimum contrast ratio
- Large text (18px+ or 14px+ bold): 3:1 minimum
- UI components: 3:1 minimum

### Focus States

```css
/* Default focus ring */
:focus-visible {
  outline: 2px solid var(--color-border-focus);
  outline-offset: 2px;
}

/* For elements where outline doesn't work well */
.focus-ring:focus-visible {
  box-shadow: 0 0 0 2px var(--color-bg-primary), 
              0 0 0 4px var(--color-border-focus);
}
```

### Interactive Element Sizing

- Minimum touch target: 44px × 44px
- Clickable elements should have adequate padding even if visually smaller

### Motion Preferences

```css
@media (prefers-reduced-motion: reduce) {
  *,
  *::before,
  *::after {
    animation-duration: 0.01ms !important;
    animation-iteration-count: 1 !important;
    transition-duration: 0.01ms !important;
  }
}
```

### Semantic HTML Requirements

- Use `<header>`, `<nav>`, `<main>`, `<section>`, `<article>`, `<footer>` appropriately
- All images require `alt` text (empty `alt=""` for decorative images)
- Form inputs must have associated `<label>` elements
- Use `aria-label` for icon-only buttons
- Implement skip links for keyboard navigation

---

## Implementation Examples

### Tailwind CSS Configuration

```javascript
// tailwind.config.js
module.exports = {
  darkMode: 'class',
  theme: {
    extend: {
      colors: {
        bg: {
          primary: 'var(--color-bg-primary)',
          secondary: 'var(--color-bg-secondary)',
          tertiary: 'var(--color-bg-tertiary)',
          elevated: 'var(--color-bg-elevated)',
        },
        text: {
          primary: 'var(--color-text-primary)',
          secondary: 'var(--color-text-secondary)',
          tertiary: 'var(--color-text-tertiary)',
        },
        accent: {
          gold: 'var(--color-accent-gold)',
          'gold-hover': 'var(--color-accent-gold-hover)',
          red: 'var(--color-accent-red)',
          'red-hover': 'var(--color-accent-red-hover)',
        },
        border: {
          primary: 'var(--color-border-primary)',
          secondary: 'var(--color-border-secondary)',
          focus: 'var(--color-border-focus)',
        },
      },
      fontFamily: {
        sans: ['Inter', 'system-ui', 'sans-serif'],
        mono: ['JetBrains Mono', 'monospace'],
      },
      aspectRatio: {
        poster: '2 / 3',
        backdrop: '16 / 9',
      },
      animation: {
        'fade-in': 'fadeIn 200ms ease-out',
        'fade-in-up': 'fadeInUp 300ms ease-out',
        shimmer: 'shimmer 1.5s infinite',
      },
    },
  },
}
```

### CSS Variables Setup

```css
/* styles/tokens.css */
:root {
  /* Include all CSS variables from this design system */
  color-scheme: dark light;
}

[data-theme="dark"] {
  color-scheme: dark;
  /* Dark mode variables */
}

[data-theme="light"] {
  color-scheme: light;
  /* Light mode variables */
}

/* System preference fallback */
@media (prefers-color-scheme: dark) {
  :root:not([data-theme]) {
    /* Dark mode as default */
  }
}
```

### React Component Example

```tsx
// components/MovieCard.tsx
interface MovieCardProps {
  title: string;
  posterUrl: string;
  year: number;
  rating: number;
  genres: string[];
}

export function MovieCard({ title, posterUrl, year, rating, genres }: MovieCardProps) {
  return (
    <article className="group relative">
      <div className="aspect-poster overflow-hidden rounded-lg bg-bg-tertiary">
        <img
          src={posterUrl}
          alt={`${title} poster`}
          className="h-full w-full object-cover transition-transform duration-300 group-hover:scale-105"
          loading="lazy"
        />
        <RatingBadge rating={rating} className="absolute right-2 top-2" />
      </div>
      <div className="mt-3">
        <h3 className="line-clamp-2 text-base font-semibold text-text-primary">
          {title}
        </h3>
        <p className="mt-1 text-sm text-text-tertiary">
          {year} • {genres.slice(0, 2).join(', ')}
        </p>
      </div>
    </article>
  );
}
```

---

## Quick Reference Card

### Most Used Tokens

| Token | Value | Usage |
|-------|-------|-------|
| `--color-bg-primary` | `#0D0D0F` / `#FAFAFA` | Page background |
| `--color-bg-secondary` | `#1A1A1F` / `#FFFFFF` | Cards |
| `--color-text-primary` | `#F5F5F7` / `#111827` | Headings |
| `--color-text-secondary` | `#9CA3AF` / `#4B5563` | Body text |
| `--color-accent-gold` | `#F5C518` / `#CA8A04` | Primary accent |
| `--color-accent-red` | `#E50914` / `#DC2626` | CTAs |
| `--radius-lg` | `0.5rem` | Standard corners |
| `--space-4` | `1rem` | Base spacing |
| `--duration-normal` | `200ms` | Standard transitions |

### Common Patterns

**Card hover effect:**
```css
transition: transform 200ms ease-out, box-shadow 200ms ease-out;
&:hover {
  transform: scale(1.03);
  box-shadow: var(--shadow-card-hover);
}
```

**Text truncation:**
```css
.line-clamp-2 {
  display: -webkit-box;
  -webkit-line-clamp: 2;
  -webkit-box-orient: vertical;
  overflow: hidden;
}
```

**Backdrop blur header:**
```css
background: rgba(13, 13, 15, 0.8);
backdrop-filter: blur(12px);
```

---

## Version History

| Version | Date | Changes |
|---------|------|---------|
| 1.0.0 | 2024-01-XX | Initial release |

---

*This design system is optimized for building modern movie database applications. Adapt tokens and components as needed while maintaining visual consistency.*
